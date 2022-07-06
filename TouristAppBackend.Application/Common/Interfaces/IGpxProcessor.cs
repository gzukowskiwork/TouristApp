using System.Collections.Generic;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.Common.Interfaces
{
    public interface IGpxProcessor
    {
        List<Coordinate> LoadGPXWaypoints(string sFile);
        List<Coordinate> LoadGPXTracks(string sFile);
    }
}
