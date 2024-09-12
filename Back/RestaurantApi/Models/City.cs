using System.Text.Json.Serialization;

namespace RestaurantApi.Models
{
    public class City
    {
        public int id { get; set; }

        public string name { get; set; }
        [JsonIgnore]
        public virtual List<Restaurant> Restuarants { get; set; } = new List<Restaurant>();

    }
}
