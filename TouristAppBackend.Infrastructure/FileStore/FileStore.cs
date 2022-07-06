using Microsoft.AspNetCore.Http;
using System.IO;
using TouristAppBackend.Application.Common.Interfaces;

namespace TouristAppBackend.Infrastructure.FileStore
{
    public class FileStore : IFileStore
    {
        private readonly IFileWrapper _fileWrapper;
        private readonly IDirectoryWrapper _directoryWrapper;

        public FileStore(IFileWrapper fileWrapper, IDirectoryWrapper directoryWrapper)
        {
            _fileWrapper = fileWrapper;
            _directoryWrapper = directoryWrapper;
        }

        public string SafeWriteFile(byte[] content, string sourceFileName, string path)
        {
            _directoryWrapper.CreateDirectory(path);
            var outputFile = Path.Combine(path, sourceFileName);
            _fileWrapper.WriteAllBytes(outputFile, content);
            return outputFile;
        }

        public byte[] GetBytes(IFormFile picture)
        {
            var memoryStream = new MemoryStream();
            picture.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
