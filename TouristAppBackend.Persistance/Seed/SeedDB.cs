using Microsoft.EntityFrameworkCore;
using System;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Persistance.Seed
{
    public static class SeedDB
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                 new User()
                 {
                     Id = 1,
                     FirstName = "Grzegorz",
                     LastName = "Zukowski",
                     Created = DateTime.Now,
                     Email = "email@email.com",
                     StatusId = 1,
                     HasAddress = true
                 },
                 new User()
                 {
                     Id = 2,
                     FirstName = "Someone",
                     LastName = "Someone",
                     Created = DateTime.Now,
                     Email = "email1@email.com",
                     StatusId = 1,
                     HasAddress = false
                 });

            modelBuilder.Entity<Address>().HasData(
                new Address()
                {
                    Id = 1,
                    CityName = "Gdańsk",
                    Created = DateTime.Now,
                    StatusId = 1,
                    UserId = 1
                });

            modelBuilder.Entity<Address>().HasData(
                new Address()
                {
                    Id = 2,
                    CityName = "Roma",
                    StatusId = 1,
                    PlaceId = 1
                });

            modelBuilder.Entity<Place>().HasData(
                new Place()
                {
                    Id = 1,
                    Name = "Coloseum",
                    Description = "Nothing special",
                    VisitedAt = DateTime.Now,
                    Created = DateTime.Now,
                    Published = DateTime.Now,
                    IsPrivate = false,
                    StatusId = 1,
                    VisitorId = 1
                });

            modelBuilder.Entity<Coordinate>().HasData(
               new Coordinate()
               {
                   Id = 1,
                   Created = DateTime.Now,
                   Longitude = 12.49237,
                   Latitude = 41.89024,
                   StatusId = 1,
                   PlaceId = 1
               });

            modelBuilder.Entity<Comment>().HasData(
               new Comment()
               {
                   Id = 1,
                   AuthorId = 2,
                   Created = DateTime.Now,
                   Content = "oh, cmon, its impressive",
                   StatusId = 1,
                   PlaceId = 1
               },
               new Comment()
               {
                   Id = 2,
                   AuthorId = 2,
                   Created = DateTime.Now,
                   Content = "nice cats",
                   StatusId = 1,
                   PictureId = 1,
                   CreatedBy = "email1@email.com"
               },
               new Comment()
               {
                   Id = 3,
                   AuthorId = 2,
                   Created = DateTime.Now,
                   Content = "nice run",
                   StatusId = 1,
                   TrackId = 1,
                   CreatedBy = "email1@email.com"
               }
               );

            modelBuilder.Entity<Rating>().HasData(
               new Rating()
               {
                   Id = 1,
                   PlaceId = 1,
                   Rank = 4
               }, new Rating()
               {
                   Id = 2,
                   PlaceId = 1,
                   Rank = 5
               }, new Rating()
               {
                   Id = 3,
                   PlaceId = 1,
                   Rank = 3
               }, new Rating()
               {
                   Id = 4,
                   PlaceId = 1,
                   Rank = 1
               }, new Rating()
               {
                   Id = 5,
                   PlaceId = 1,
                   Rank = 4
               }, new Rating()
               {
                   Id = 6,
                   PlaceId = 1,
                   Rank = 4
               }, new Rating()
               {
                   Id = 7,
                   PlaceId = 1,
                   Rank = 4
               }, new Rating()
               {
                   Id = 8,
                   PlaceId = 1,
                   Rank = 4
               }, new Rating()
               {
                   Id = 9,
                   PlaceId = 1,
                   Rank = 4
               }, new Rating()
               {
                   Id = 10,
                   PlaceId = 1,
                   Rank = 4
               }, new Rating()
               {
                   Id = 11,
                   PlaceId = 1,
                   Rank = 4
               });
        }
    }
}
