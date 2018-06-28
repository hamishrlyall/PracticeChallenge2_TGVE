using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TGVE.Models;

namespace TGVE.ViewModels
{
    public class TourEventsIndexData
    {
        public IEnumerable<Booking> Bookings { get; set; }
        public IEnumerable<Client> Clients { get; set; }
        public IEnumerable<Tour> Tours { get; set; }
        public IEnumerable<TourEvent> TourEvents { get; set; }
    }
}