using BookStore.Models;

namespace BookStore.Helpers
{
    public static class DeliveryInfoGenerator
    {
        public static string Generate(MotorbikeDeliveryInfo info)
        {
            return $"Driver name: {info.Driver}\r\n " +
                   $"Mobile: {info.Mobile}\r\n" +
                   $" Delivery date: {info.DeliveryDate:dd/MM/yyyy}\r\n" +
                   $"Cost: {info.DeliveryCost}";
        }

        public static string Generate(TrainDeliveryInfo info)
        {
            return $"Train Train no: {info.TrainNo}\r\n" +
                   $"Station of arrival: {info.StationName}\r\n" +
                   $"Date of arrival: {info.ArrivalDate:dd/MM/yyyy}\r\n" +
                   $"Cost: {info.DeliveryCost}";
        }

        public static string Generate(AircraftDeliveryInfo info)
        {
            return $"Aircraft Flight no: {info.FlightNo}\r\n" +
                   $"Gate of arrival: {info.GateNumber}\r\n" +
                   $"Date of arrival: {info.ArrivalDate:dd/MM/yyyy}\r\n" +
                   $"Cost: {info.DeliveryCost}";
        }

    }
}