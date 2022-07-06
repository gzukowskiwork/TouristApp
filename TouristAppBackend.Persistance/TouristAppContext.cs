using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using TouristAppBackend.Application.Common.Interfaces;
using TouristAppBackend.Domain.Common;
using TouristAppBackend.Domain.Models;
using TouristAppBackend.Persistance.Seed;

namespace TouristAppBackend.Persistance
{
    public class TouristAppContext : DbContext, ITouristAppContext
    {
        private readonly IDateTime _dateTime;
        private readonly ICurrentUserService _currentUserService;

        public TouristAppContext(DbContextOptions<TouristAppContext> options) : base(options)
        {
        }

        public TouristAppContext(DbContextOptions<TouristAppContext> options, IDateTime dateTime, ICurrentUserService currentUserService) : base(options)
        {
            _dateTime = dateTime;
            _currentUserService = currentUserService;
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Coordinate> Coordinates { get; set; }
        public DbSet<Forecast> Forecasts { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<GpxFile> GpxFiles { get; set; }
        public DbSet<Settings> Settings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.SeedData();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entity in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entity.State)
                {
                    case EntityState.Added:
                        entity.Entity.Created = _dateTime.Now;
                        entity.Entity.StatusId = 1;
                        entity.Entity.CreatedBy = _currentUserService.Email;
                        break;
                    case EntityState.Modified:
                        entity.Entity.Modified = _dateTime.Now;
                        entity.Entity.StatusId = 2;
                        entity.Entity.ModifiedBy = _currentUserService.Email;
                        break;
                    case EntityState.Deleted:
                        entity.Entity.ModifiedBy = _currentUserService.Email;
                        entity.Entity.Inactivated = _dateTime.Now;
                        entity.Entity.InactivatedBy = _currentUserService.Email;
                        entity.Entity.Modified = _dateTime.Now;
                        entity.Entity.StatusId = 0;
                        entity.State = EntityState.Modified;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
