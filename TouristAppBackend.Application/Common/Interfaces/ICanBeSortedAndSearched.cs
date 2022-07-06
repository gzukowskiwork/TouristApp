using System;

namespace TouristAppBackend.Application.Common
{
    public interface ICanBeSortedAndSearched
    {
        int Quantity { get; }
        string SearchString { get; }
        string AscDesc { get; }
        DateTime? From { get; set; }
        DateTime? To { get; set; }
    }
}