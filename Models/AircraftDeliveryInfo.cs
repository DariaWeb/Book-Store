using System;

namespace BookStore.Models
{
    public class AircraftDeliveryInfo
    {
        public string FlightNo { get; set; }
        public string GateNumber { get; set; }
        public DateTime ArrivalDate { get; set; }
        public decimal DeliveryCost { get; set; }
    }
}
