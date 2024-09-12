namespace RestaurantApi.DTO
{
    public class FoodDTO2
    {
        public string foodName { get; set; }

        public string foodDescription { get; set; }

        public int foodPrice { get; set; }
        public int Restaurantid { get; set; }


        public IFormFile foodPicture { get; set; }
    }
}
