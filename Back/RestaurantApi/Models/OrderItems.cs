using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantApi.Models
{
    public class OrderItems
    {
        [Key]
        public int OrderItemId { get; set; }
        
        public string OrderItemName { get; set; }

        public string OrderItemPicture { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }
    
        public Order Order { get; set; }

    }
}
