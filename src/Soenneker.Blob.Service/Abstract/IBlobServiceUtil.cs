using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;

namespace Soenneker.Blob.Service.Abstract;

/// <summary>
/// Provides the configured Azure Blob Storage service client.
/// </summary>
public interface IBlobServiceUtil : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the lazily created, cached service client.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel client initialization.</param>
    /// <returns>The client owned by this utility instance.</returns>
    ValueTask<BlobServiceClient> Get(CancellationToken cancellationToken = default);
}
