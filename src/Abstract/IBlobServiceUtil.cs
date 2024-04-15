using System;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using Azure.Storage.Blobs;

namespace Soenneker.Blob.Service.Abstract;

/// <summary>
/// 
/// </summary>
public interface IBlobServiceUtil : IDisposable, IAsyncDisposable
{
    [Pure]
    ValueTask<BlobServiceClient> Get();
}