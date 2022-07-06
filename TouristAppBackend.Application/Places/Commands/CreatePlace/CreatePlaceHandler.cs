using AutoMapper;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TouristAppBackend.Application.Common.Interfaces;
using TouristAppBackend.Domain.Models;


namespace TouristAppBackend.Application.Places.Commands.CreatePlace
{
    public class CreatePlaceHandler : IRequestHandler<CreatePlaceCommand, int>
    {
        private readonly ITouristAppContext _touristAppContext;
        private readonly IMapper _mapper;
        private readonly IDateTime _dateTime;

        public CreatePlaceHandler(ITouristAppContext touristAppContext, IMapper mapper, IDateTime dateTime)
        {
            _touristAppContext = touristAppContext;
            _mapper = mapper;
            _dateTime = dateTime;
        }

        public async Task<int> Handle(CreatePlaceCommand request, CancellationToken cancellationToken)
        {
            var place = _mapper.Map<Place>(request);
            place.CreatedBy = _touristAppContext.Users.Where(u => u.Id == place.VisitorId).Select(s => s.FirstName).FirstOrDefault();
            place.StatusId = 1;
            place.Published = _dateTime.Now;

            _touristAppContext.Places.Add(place);

            await _touristAppContext.SaveChangesAsync(cancellationToken);

            return place.Id;
        }
    }
}
