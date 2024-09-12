using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantApi.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [ForeignKey("City")]
        public int CityId { get; set; }
        public string RestuarantPicture { get; set; }
        public City City { get; set; }

        public virtual List<Food> Menu { get; set; } = new List<Food>();
    }
}
