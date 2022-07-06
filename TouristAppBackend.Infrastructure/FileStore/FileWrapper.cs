using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using TouristAppBackend.Application.Common.Interfaces;

namespace TouristAppBackend.Infrastructure.FileStore
{
    public class FileWrapper : IFileWrapper
    {
        public byte[] ReadFileAsync(string path)
        {
            throw new System.NotImplementedException();
        }

        public void WriteAllBytes(string output, byte[] content)
        {
            File.WriteAllBytes(output, content);
        }
    }
}
