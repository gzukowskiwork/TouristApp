using Microsoft.AspNetCore.Http;

namespace TouristAppBackend.Application.Common.Interfaces
{
    public interface IFileStore
    {
        string SafeWriteFile(byte[] content, string sourceFileName, string path);
        byte[] GetBytes(IFormFile picture);
    }
}
