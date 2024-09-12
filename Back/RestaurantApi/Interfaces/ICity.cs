using RestaurantApi.DTO;
using RestaurantApi.Models;

namespace RestaurantApi.Interfaces
{
    public interface ICity
    {
        public City AddCity(CityDTO city);
        public List<City> GetAll();
    }
}
