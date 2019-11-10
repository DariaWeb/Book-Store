using BookStore.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BookStore.Models
{
    public class BookInfo
    {
        public string Authors { get; set; }

        public string Title { get; set; }

        public string PublishedDate { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }
    }

    public class BookDeliveryOption
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public DeliveryType Type { get; set; }

        public decimal Cost { get; set; }
    }
}
