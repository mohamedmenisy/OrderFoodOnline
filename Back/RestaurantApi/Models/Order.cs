using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RestaurantApi.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        
        public int TotalPrice { get; set; }
        public Customer Customer { get; set; }
      
        public virtual List<OrderItems> OrderItems { get; set; } = new List<OrderItems>();


    }
}
