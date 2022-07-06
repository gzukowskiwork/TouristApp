using AutoMapper;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TouristAppBackend.Application.Common.Interfaces;
using TouristAppBackend.Application.Common.Interfaces.Validators;
using TouristAppBackend.Common;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.Tracks.Commands.CreateTrack
{
    public class CreateTrackCommandHandler : IRequestHandler<CreateTrackCommand, bool>
    {
        private readonly ITouristAppContext _touristAppContext;
        private readonly IMapper _mapper;
        private readonly IGpxProcessor _gpxProcessor;
        private readonly IDateTime _dateTime;
        private readonly IUserExistsValidator _userExistsValidator;
        private readonly ICurrentUserService _currentUserService;

        public CreateTrackCommandHandler(
            ITouristAppContext touristAppContext,
            IMapper mapper,
            IGpxProcessor gpxProcessor,
            IDateTime dateTime,
            IUserExistsValidator userExistsValidator,
            ICurrentUserService userService
            )
        {
            _touristAppContext = touristAppContext;
            _mapper = mapper;
            _gpxProcessor = gpxProcessor;
            _dateTime = dateTime;
            _userExistsValidator = userExistsValidator;
            _currentUserService = userService;
        }

        public async Task<bool> Handle(CreateTrackCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(string.Format(Constants.ErrorMesseges.RequestCannotBeNull, nameof(request)));
            }

            Track track = _mapper.Map<Track>(request);

            if (track == null)
            {
                throw new ArgumentNullException(Constants.ErrorMesseges.TrackCanotBeNull);
            }

            //int authorId = _touristAppContext.Users.Where(u => u.Email == _currentUserService.Email).FirstOrDefault().Id;
            track.AuthorId = 1;
            track.Coordinates = _gpxProcessor.LoadGPXTracks(request.PathToFile);

            if (_touristAppContext.GpxFiles.Any(x => x.FileName.Equals(request.PathToFile.Substring(request.PathToFile.Length - 40))))
            {
                PopulateGpxFileId(request, track);
            }

            _userExistsValidator.Validate(1);

            try
            {
                //track.CreatedBy = _touristAppContext.Users.Where(x=>x.Id == request.AuthorId).FirstOrDefault().Email;
                _touristAppContext.Tracks.Add(track);
                await _touristAppContext.SaveChangesAsync(cancellationToken);

                return true;
            }
            catch (Exception e)
            {
                return false;
                throw new Exception(string.Format(Constants.ErrorMesseges.SomethingWentWrong, e.Message, e.StackTrace));
            }
        }

        private void PopulateGpxFileId(CreateTrackCommand request, Track track)
        {
            int gpxFileId = _touristAppContext.GpxFiles.Where(x => x.FileName.Equals(request.PathToFile.Substring(request.PathToFile.Length - 40))).FirstOrDefault().Id;
            var date = _dateTime.Now;
            foreach (var item in track.Coordinates)
            {
                item.Created = date;
                item.BasedOnGpxFileId = gpxFileId;
            }
        }
    }
}
