using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TouristAppBackend.Application.Common.Interfaces;
using TouristAppBackend.Common;

namespace TouristAppBackend.Application.Address.Queries.GetAllAddresses
{
    public class GetAllAddressesQueryHandler : IRequestHandler<GetAllAddressesQuery, GetAllAddressesVm>
    {
        private readonly ITouristAppContext _touristAppContext;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public GetAllAddressesQueryHandler(ITouristAppContext touristAppContext, IMapper mapper, ICurrentUserService currentUserService)
        {
            _touristAppContext = touristAppContext;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<GetAllAddressesVm> Handle(GetAllAddressesQuery request, CancellationToken cancellationToken)
        {
            var addresses = _touristAppContext.Addresses.Where(a => a.StatusId != 0 && a.Id > 0).Where(a=>a.CreatedBy == _currentUserService.Email);

            if(addresses == null)
            {
                throw new ArgumentOutOfRangeException(Constants.ErrorMesseges.AddressesAreEmpty);
            }

            List<GetAllAddressesDto> addressesDtos = await addresses
                .ProjectTo<GetAllAddressesDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            GetAllAddressesVm getAllAddressesVm = new GetAllAddressesVm
            {
                AddressesDtos = addressesDtos
            };

            return getAllAddressesVm;
        }
    }
}
