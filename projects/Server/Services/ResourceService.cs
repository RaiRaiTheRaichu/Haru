using Haru.Repositories;
using Haru.Server.Services;

namespace Haru.Server.Services
{
    public static class ResourceService
    {
        public bool HasFile(string url)
        {
            return ResourceRepository.HasFile(url);
        }

        public string GetFile(string url)
        {
            return ResourceRepository.GetFile(url);
        }

        public string[] GetFileNames()
        {
            return ResourceRepository.GetFileNames();
        }
    }
}