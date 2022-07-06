using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace TouristAppBackend.Application.Common.Interfaces
{
    public interface IFileWrapper
    {
        void WriteAllBytes(string output, byte[] content);
        byte[] ReadFileAsync(string path);
    }
}
