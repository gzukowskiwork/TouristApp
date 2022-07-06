using AutoMapper;
using System.Collections.Generic;
using TouristAppBackend.Application.Common.Mapping;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.Tracks.Queries.GetTrackDetail
{
    public class GetTrackDetailVm : IMapFrom<Track>
    {
        public string TrackName { get; set; }
        public string Description { get; set; }
        public bool IsPrivate { get; set; }
        public int AuthorId { get; set; }
        public double AvarageRate { get; set; }
        public ICollection<GetCoordinatesVm> GetCoordinatesVm { get; set; }
        public ICollection<GetTrackCommentsVm> GetTrackCommentsVm { get; set; }
        public ICollection<GetTrackPictureVm> GetTrackPicturesVm { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Track, GetTrackDetailVm>()
                .ForMember(c => c.GetCoordinatesVm, map => map.MapFrom(t => t.Coordinates))
                .ForMember(c => c.GetTrackPicturesVm, map => map.MapFrom(t => t.Pictures))
                .ForMember(c => c.GetTrackCommentsVm, map => map.MapFrom(t => t.Comments));
        }


    }
}
