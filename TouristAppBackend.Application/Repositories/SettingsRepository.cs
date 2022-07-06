using System.Linq;
using TouristAppBackend.Application.Common.Interfaces;
using TouristAppBackend.Application.Common.Interfaces.Repository;

namespace TouristAppBackend.Application.Repositories
{
    public class SettingsRepository : ISettingsRepository
    {
        private readonly ITouristAppContext _touristAppContext;

        public SettingsRepository(
            ITouristAppContext touristAppContext
            )
        {
            _touristAppContext = touristAppContext;
        }

        public string GetByCode(string code)
        {
            return _touristAppContext.Settings.Where(x => x.Code == code).FirstOrDefault().Value;
        }
    }
}
