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
    /// Gets the value.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the operation.</returns>
    [Pure]
    ValueTask<BlobServiceClient> Get(CancellationToken cancellationToken = default);
}