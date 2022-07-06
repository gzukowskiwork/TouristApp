using AutoMapper;
using MediatR;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TouristAppBackend.Application.Common.Interfaces;
using TouristAppBackend.Application.Common.Interfaces.Validators;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.GpxFiles.Commands.UploadGpx
{
    public class CreateGpxHandler : IRequestHandler<CreateGpxCommand, string>
    {
        private readonly ITouristAppContext _touristAppContext;
        private readonly IMapper _mapper;
        private readonly IFileStore _fileStore;
        private readonly IGpxFileValidator _gpxFileValidator;

        public CreateGpxHandler(
            ITouristAppContext touristAppContext,
            IMapper mapper,
            IFileStore fileStore,
            IGpxFileValidator gpxFileValidator
            )
        {
            _touristAppContext = touristAppContext;
            _mapper = mapper;
            _fileStore = fileStore;
            _gpxFileValidator = gpxFileValidator;
        }

        public async Task<string> Handle(CreateGpxCommand request, CancellationToken cancellationToken)
        {
            var gpxFile = _mapper.Map<GpxFile>(request);

            _gpxFileValidator.Validte(request.GpxFile);

            var folderName = Path.Combine("StaticFiles", "GPX");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            var bytes = _fileStore.GetBytes(request.GpxFile);

            gpxFile.FileName = Guid.NewGuid().ToString() + ".gpx";
            gpxFile.PathToFile = _fileStore.SafeWriteFile(bytes, gpxFile.FileName, pathToSave);

            _touristAppContext.GpxFiles.Add(gpxFile);
            await _touristAppContext.SaveChangesAsync(cancellationToken);

            return gpxFile.PathToFile;
        }
    }
}
