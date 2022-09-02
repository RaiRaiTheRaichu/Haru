using Haru.Server.Repositories;

namespace Haru.Server.Services
{
    public static class ResourceService
    {
        public static bool HasFile(string url)
        {
            return ResourceRepository.HasFile(url);
        }

        public static string GetFile(string url)
        {
            return ResourceRepository.GetFile(url);
        }
    }
}