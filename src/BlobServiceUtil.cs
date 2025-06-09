using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using Soenneker.Blob.Service.Abstract;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.ValueTask;
using Soenneker.Utils.AsyncSingleton;
using Soenneker.Utils.HttpClientCache.Abstract;

namespace Soenneker.Blob.Service;

///<inheritdoc cref="IBlobServiceUtil"/>
public sealed class BlobServiceUtil : IBlobServiceUtil
{
    private readonly IHttpClientCache _httpClientCache;
    private readonly AsyncSingleton<BlobServiceClient> _client;

    public BlobServiceUtil(IConfiguration config, IHttpClientCache httpClientCache)
    {
        _httpClientCache = httpClientCache;
        _client = new AsyncSingleton<BlobServiceClient>(async (token, _) =>
        {
            HttpClient client = await httpClientCache.Get(nameof(BlobServiceUtil), cancellationToken: token).NoSync();

            var clientOptions = new BlobClientOptions
            {
                Transport = new HttpClientTransport(client)
            };

            var connectionString = config.GetValueStrict<string>("Azure:Storage:Blob:ConnectionString");
            return new BlobServiceClient(connectionString, clientOptions);
        });
    }

    public ValueTask<BlobServiceClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public async ValueTask DisposeAsync()
    {
        await _client.DisposeAsync().NoSync();
        await _httpClientCache.Remove(nameof(BlobServiceUtil)).NoSync();
    }

    public void Dispose()
    {
        _client.Dispose();
        _httpClientCache.RemoveSync(nameof(BlobServiceUtil));
    }
}