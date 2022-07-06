using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TouristAppBackend.Application.Common.Interfaces;
using TouristAppBackend.Common;

namespace TouristAppBackend.Application.Address.Queries.GetAddress
{
    public class GetAddressQueryHandler : IRequestHandler<GetAddressQuery, GetAddressDetailsVm>
    {
        private readonly ITouristAppContext _touristAppContext;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public GetAddressQueryHandler(ITouristAppContext touristAppContext, IMapper mapper, ICurrentUserService currentUserService)
        {
            _touristAppContext = touristAppContext;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<GetAddressDetailsVm> Handle(GetAddressQuery request, CancellationToken cancellationToken)
        {
            if(request == null)
            {
                throw new ArgumentNullException(string.Format(Constants.ErrorMesseges.RequestCannotBeNull, nameof(request)));
            }

            Domain.Models.Address address = await _touristAppContext.Addresses.Where(x=>x.StatusId != 0)
                .Where(a => a.Id == request.AddressId && a.CreatedBy == _currentUserService.Email)
                .FirstOrDefaultAsync(cancellationToken);

            if(address == null)
            {
                throw new ArgumentOutOfRangeException(string.Format(Constants.ErrorMesseges.AddressDoesNotExists, request.AddressId));
            }

            GetAddressDetailsVm getAddressVm = _mapper.Map<GetAddressDetailsVm>(address);

            return getAddressVm;
        }
    }
}
