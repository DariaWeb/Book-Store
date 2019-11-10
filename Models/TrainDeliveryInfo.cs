using System;

namespace BookStore.Models
{
    public class TrainDeliveryInfo
    {
        public string TrainNo { get; set; }
        public string StationName { get; set; }
        public DateTime ArrivalDate { get; set; }
        public decimal DeliveryCost { get; set; }
    }
}
