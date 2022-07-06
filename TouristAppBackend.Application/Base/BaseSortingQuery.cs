using System;

namespace TouristAppBackend.Application.Base
{
    public class BaseSortingQuery
    {
        public int Quantity { get; }
        public string SearchString { get; }
        public string AscDesc { get; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }

        public BaseSortingQuery(int quantity, string searchString, string ascDesc, DateTime? from, DateTime? to)
        {
            Quantity = quantity;
            SearchString = searchString;
            AscDesc = ascDesc;
            From = from;
            To = to;
        }
    }
}
