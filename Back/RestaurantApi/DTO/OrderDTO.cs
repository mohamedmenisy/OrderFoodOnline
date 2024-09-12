namespace RestaurantApi.DTO
{
    public class OrderDTO
    {
        public CustomerDTO Customer { get; set; }

        public List<OrderItemDTO> orderItems { get; set; }

        public int TotalPrice { get; set; }
    }
}
