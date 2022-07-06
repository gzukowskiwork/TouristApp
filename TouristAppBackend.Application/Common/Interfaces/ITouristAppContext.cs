using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.Common.Interfaces
{
    public interface ITouristAppContext
    {
        DbSet<Domain.Models.Address> Addresses { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<Coordinate> Coordinates { get; set; }
        DbSet<Forecast> Forecasts { get; set; }
        DbSet<Picture> Pictures { get; set; }
        DbSet<Place> Places { get; set; }
        DbSet<Rating> Ratings { get; set; }
        DbSet<Track> Tracks { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<GpxFile> GpxFiles { get; set; }
        DbSet<Settings> Settings { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
