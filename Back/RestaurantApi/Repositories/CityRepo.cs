using Microsoft.EntityFrameworkCore;
using RestaurantApi.DTO;
using RestaurantApi.Interfaces;
using RestaurantApi.Models;
using RestaurantApi.Context;

namespace RestaurantApi.Repositories
{

    public class CityRepo : ICity
    {
        private readonly RestaurantContext context;

        public CityRepo(RestaurantContext _context)
        {
            context = _context;
        }
        public City AddCity(CityDTO _city)
        {
            City city =new City() { 
                name=_city.CityName
            
            };
           context.Cities.Add(city);
            context.SaveChanges();
            return city;
        }

        public List<City> GetAll()
        {
           var allCities = context.Cities.Include(c=>c.Restuarants).ToList();
            return allCities;
        }
    }
}
