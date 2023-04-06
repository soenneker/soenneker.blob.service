using System;
using System.Net.Http;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using Soenneker.Blob.Service.Abstract;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Blob.Service;

///<inheritdoc cref="IBlobServiceUtil"/>
public class BlobServiceUtil : IBlobServiceUtil
{
    private readonly AsyncSingleton<BlobServiceClient> _client;

    public BlobServiceUtil(IConfiguration config)
    {
        _client = new AsyncSingleton<BlobServiceClient>(() =>
        {
            var socketsHandler = new SocketsHttpHandler
            {
                PooledConnectionLifetime = TimeSpan.FromMinutes(10),
                MaxConnectionsPerServer = 30
            };

            var httpClient = new HttpClient(socketsHandler);

            var clientOptions = new BlobClientOptions
            {
                Transport = new HttpClientTransport(httpClient)
            };

            var connectionString = config.GetValue<string>("Azure:Storage:Blob:ConnectionString");

            if (connectionString == null)
                throw new Exception("Azure:Storage:Blob:ConnectionString config is expected");

            return new BlobServiceClient(connectionString!, clientOptions);
        });
    }

    public ValueTask<BlobServiceClient> GetClient()
    {
        return _client.Get();
    }

    public ValueTask DisposeAsync()
    {
        GC.SuppressFinalize(this);

        return _client.DisposeAsync();
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);

        _client.Dispose();
    }
}