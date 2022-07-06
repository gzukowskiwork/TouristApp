using AutoMapper;
using System;
using TouristAppBackend.Application.Common.Mapping;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.Places.Commands.UpdatePlace
{
    public class UpdateCoordinatesVm : IMapFrom<Coordinate>
    {
        public int Id { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double? Altitude { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateCoordinatesVm, Coordinate>();
        }
    }
}
