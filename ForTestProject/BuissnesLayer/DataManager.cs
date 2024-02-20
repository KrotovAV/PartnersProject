using BuissnesLayer.Implementions;
using BuissnesLayer.Interfaces;

namespace BuissnesLayer
{
    public class DataManager
    {
        private IDirectrysRepository _directrysRepository;
        private IMaterialsRepository _materialsRepository;

        public DataManager(IDirectrysRepository directrysRepository, IMaterialsRepository materialsRepository)
        {
            _directrysRepository = directrysRepository;
            _materialsRepository = materialsRepository;
        }

        public IDirectrysRepository Directrys { get { return _directrysRepository; } }
        public IMaterialsRepository Materials { get { return _materialsRepository; } }
    }
}