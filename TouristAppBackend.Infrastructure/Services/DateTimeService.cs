using System;
using TouristAppBackend.Application.Common.Interfaces;

namespace TouristAppBackend.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
