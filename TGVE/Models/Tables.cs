using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TGVE.Models
{
    public class Tours
    {
        public string TourName { get; set; }
        public string Description { get; set; }
    }
    public class Clients
    {
        public int ClientID { get; set; }
        public string Surname { get; set; }
        public string GivenName { get; set; }
        public string Gender { get; set; }
    }
    public class TourEvents
    {
        public int EventID { get; set; }
        public DateTime EventDate;
        public decimal Fee { get; set; }
        public string TourName { get; set; }
    }
    public class Bookings
    {
        public int BookingID { get; set; }
        public int ClientID { get; set; }
        public string TourName { get; set; }
        public DateTime EventDate;
        public decimal Payment { get; set; }
        public DateTime DateBooked;
    }
}