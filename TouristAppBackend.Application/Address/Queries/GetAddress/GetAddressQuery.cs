using MediatR;

namespace TouristAppBackend.Application.Address.Queries.GetAddress
{
    public class GetAddressQuery : IRequest<GetAddressDetailsVm>
    {
        public int AddressId { get; set; }
    }
}
