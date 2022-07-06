using AutoMapper;
using MediatR;
using TouristAppBackend.Application.Common.Mapping;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.Tracks.Commands.CreateTrack
{
    public class CreateTrackCommand : IRequest<bool>, IMapFrom<Track>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPrivate { get; set; }
        //public int AuthorId { get; set; }
        public string PathToFile { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateTrackCommand, Track>()
                .ForSourceMember(x => x.PathToFile, opt => opt.DoNotValidate());
        }

    }
}
