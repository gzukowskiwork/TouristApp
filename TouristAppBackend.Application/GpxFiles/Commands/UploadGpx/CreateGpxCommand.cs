using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using TouristAppBackend.Application.Common.Mapping;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.GpxFiles.Commands.UploadGpx
{
    public class CreateGpxCommand : IRequest<string>, IMapFrom<GpxFile>
    {
        public IFormFile GpxFile { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateGpxCommand, GpxFile>()
             .ForSourceMember(g => g.GpxFile, opt => opt.DoNotValidate());
        }
    }
}
