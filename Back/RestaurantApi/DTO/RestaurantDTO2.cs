using Azure.Core;

namespace RestaurantApi.DTO
{
    public class RestaurantDTO2
    {
        public string RestuarantName { get; set; }
        public string Description { get; set; }

        public int cityid { get; set; }
        public IFormFile RestuarantPicture { get; set; }
      
    }
}
