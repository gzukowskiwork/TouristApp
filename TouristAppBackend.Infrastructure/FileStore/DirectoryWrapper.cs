using System.IO;
using TouristAppBackend.Application.Common.Interfaces;

namespace TouristAppBackend.Infrastructure.FileStore
{
    public class DirectoryWrapper : IDirectoryWrapper
    {
        public void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }
    }
}
