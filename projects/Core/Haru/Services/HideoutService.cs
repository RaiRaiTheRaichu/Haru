using Haru.Models.EFT.Hideout;
using Haru.Repositories;

namespace Haru.Services
{
    public class HideoutService
    {
        private readonly HideoutRepository _hideoutRepository;

        public HideoutService()
        {
            _hideoutRepository = new HideoutRepository();
        }

        public SettingsModel GetSettings()
        {
            return _hideoutRepository.GetSettings();
        }

        public ScavcaseModel[] GetScavcases()
        {
            return _hideoutRepository.GetScavcases();
        }
    }
}