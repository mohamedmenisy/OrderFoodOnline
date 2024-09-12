using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantApi.Models
{
    public class Food
    {
       public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string Picture { get; set; }
        public int Price { get; set; }
        [ForeignKey("Restuarant")]
        public int RestuarantId {  get; set; }
        
        public Restaurant Restuarant { get; set; }
    }
}
