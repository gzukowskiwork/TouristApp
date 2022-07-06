using System;

namespace TouristAppBackend.Domain.Common
{
    public interface IProperties
    {
        string Name { get; set; }

        string Description { get; set; }

        public DateTime? VisitedAt { get; set; }
    }
}
