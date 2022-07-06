using AutoMapper;
using System;
using System.Collections.Generic;
using TouristAppBackend.Application.Common.Mapping;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.Tracks.Queries.GetTrackDetail
{
    public class GetTrackPictureVm: IMapFrom<Picture>
    {
        public string PathToImage { get; set; }
        public string PhotoName { get; set; }
        public string Description { get; set; }
        public bool IsPrivate { get; set; }
        public double AvarageRate { get; set; }
        public DateTime Taken { get; set; }
        public ICollection<GetPictureCommentsVm> GetPictureCommentsVm { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Picture, GetTrackPictureVm>()
                .ForMember(x => x.GetPictureCommentsVm, map => map.MapFrom(p => p.Comments));
        }

    }
}