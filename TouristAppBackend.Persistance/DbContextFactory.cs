using Microsoft.EntityFrameworkCore;

namespace TouristAppBackend.Persistance
{
    public class DbContextFactory : DesignTimeDBContextFactoryBase<TouristAppContext>
    {
        protected override TouristAppContext CreateNewInstance(DbContextOptions<TouristAppContext> options)
        {
            return new TouristAppContext(options);
        }
    }
}
