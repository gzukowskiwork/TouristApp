using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using TouristAppBackend.Application.Common.Mapping;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.Images.Commands.UploadImage
{
    public class CreateImageCommand : IRequest<string>, IMapFrom<Picture>
    {
        public string PhotoName { get; set; }
        public string Description { get; set; }
        public bool IsPrivate { get; set; }
        public DateTime Taken { get; set; }
        public int AuthorId { get; set; }
        public int? PlaceId { get; set; }
        public int? TrackId { get; set; }
        public IFormFile Picture { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateImageCommand, Picture>()
                .ForSourceMember(p => p.Picture, opt => opt.DoNotValidate())
                .ForMember(p=>p.PhotoOfPlaceId, map=>map.MapFrom(x=>x.PlaceId))
                .ForMember(p=>p.PhotoOfTrackId, map=>map.MapFrom(x=>x.TrackId));
        }
    }
}
