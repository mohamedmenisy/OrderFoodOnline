using RestaurantApi.DTO;
using RestaurantApi.Models;

namespace RestaurantApi.Interfaces
{
    public interface IRestaurant
    {
        public List<RestaurantDTO> GetRestuarants(int cityid, string restuarantName);
        public List<FoodDTO> GetMenu(int restaurantId);
        public Models.Restaurant SetRestaurant(Models.Restaurant _restaurant);
        public Food SetFood(Food _food);


    }
}
