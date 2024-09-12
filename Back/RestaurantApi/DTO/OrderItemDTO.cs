namespace RestaurantApi.DTO
{
    public class OrderItemDTO
    {
        public int foodId { get; set; }

        public string foodName { get; set; }

        public string foodDescription { get; set; }

        public int quantity { get; set; }  

        public int foodPrice { get; set; }

        public string foodPicture { get; set; }
    }
}
