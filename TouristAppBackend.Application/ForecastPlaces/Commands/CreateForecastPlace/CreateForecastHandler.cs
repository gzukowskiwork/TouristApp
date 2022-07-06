using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TouristAppBackend.Application.Common.Interfaces;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.ForecastPlaces.Commands.CreateForecastPlace
{
    public class CreateForecastHandler : IRequestHandler<CreateForecastCommand, int>
    {
        private readonly ITouristAppContext _touristAppContext;
        private readonly IMapper _mapper;
        private readonly IDateTime _dateTime;

        public CreateForecastHandler(ITouristAppContext touristAppContext, IMapper mapper, IDateTime dateTime)
        {
            _touristAppContext = touristAppContext;
            _mapper = mapper;
            _dateTime = dateTime;
        }

        public async Task<int> Handle(CreateForecastCommand request, CancellationToken cancellationToken)
        {
            var forecastPlace = _mapper.Map<Forecast>(request);
            var user = await _touristAppContext.Users.Where(u => u.Id == request.UserId).FirstOrDefaultAsync();

            forecastPlace.StatusId = 1;
            forecastPlace.Created = _dateTime.Now;
            //forecastPlace.CreatedBy = user.Email;

            _touristAppContext.Forecasts.Add(forecastPlace);

            await _touristAppContext.SaveChangesAsync(cancellationToken);

            return forecastPlace.Id;
        }
    }
}
