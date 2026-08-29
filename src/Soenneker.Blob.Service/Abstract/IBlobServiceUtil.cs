using System;
using System.Diagnostics.Contracts;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;

namespace Soenneker.Blob.Service.Abstract;

/// <summary>
/// 
/// </summary>
public interface IBlobServiceUtil : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Returns the configured blob Service Client used by the blob service.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the requested blob Service Client.</returns>
    [Pure]
    ValueTask<BlobServiceClient> Get(CancellationToken cancellationToken = default);
}
