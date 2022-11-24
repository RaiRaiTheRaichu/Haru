using Haru.Repositories;

namespace Haru.Services
{
    public class ResourceService
    {
        private readonly ResourceRepository _resourceRepository;

        public ResourceService()
        {
            _resourceRepository = new ResourceRepository();
        }

        public bool HasFile(string url)
        {
            return _resourceRepository.HasFile(url);
        }

        public string GetFile(string url)
        {
            return _resourceRepository.GetFile(url);
        }
    }
}