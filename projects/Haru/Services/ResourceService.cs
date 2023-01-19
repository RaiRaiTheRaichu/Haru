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

        public bool TryGetFile(string path, out string file)
        {
            return _resourceRepository.TryGetFile(path, out file);
        }
    }
}