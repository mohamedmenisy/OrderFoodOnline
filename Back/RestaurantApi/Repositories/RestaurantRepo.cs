using Microsoft.EntityFrameworkCore;
using RestaurantApi.Context;
using RestaurantApi.DTO;
using RestaurantApi.Interfaces;
using RestaurantApi.Models;
using System.Collections.Generic;

namespace RestaurantApi.Repositories
{
    public class RestaurantRepo : IRestaurant
    {
        private readonly RestaurantContext context;

        public RestaurantRepo(RestaurantContext _context)
        {
            context = _context;
        }
        public List<RestaurantDTO> GetRestuarants(int cityid, string restuarantName)
        {
            var Resturants = new List<RestaurantDTO>();
            var rest=new List<Models.Restaurant>();
            if (restuarantName != null)
            {
                 rest = context.Restaurants.Include(r => r.City).Where(r => r.CityId == cityid && r.Name.ToLower().Contains(restuarantName.ToLower())).ToList();

            }
            else
            {
                rest = context.Restaurants.Include(r => r.City).Where(r => r.CityId == cityid ).ToList();

            }
            foreach (var r in rest)
            {
                RestaurantDTO restuarantDTO = new RestaurantDTO() { 
                   Id = r.Id,
                   Description = r.Description,
                   Location = r.City.name,
                   RestuarantName= r.Name,
                   RestuarantPicture=r.RestuarantPicture
                
                };
                Resturants.Add(restuarantDTO);
            }
            return Resturants;
        }

        public List<FoodDTO> GetMenu(int restaurantId)
        {
            var Menu = new List<FoodDTO>();
            
            var restaurant = context.Restaurants.Include(r=>r.Menu).FirstOrDefault(x=>x.Id == restaurantId);
            if (restaurant != null)
            {
                foreach (var item in restaurant.Menu)
                {
                    FoodDTO foodDto = new FoodDTO()
                    {
                        foodId = item.Id,
                        foodName = item.Name,
                        foodDescription = item.Description,
                        foodPicture = item.Picture,
                        foodPrice = item.Price
                    };
                    Menu.Add(foodDto);
                }
            }
          
            return Menu;
        }
        public List<Food> getOrderItems(List<int> ints) {
            List <Food> foods = new List<Food >();
            foreach (var item in ints)
            {
                Food food = this.context.Foods.FirstOrDefault(x => x.Id == item);
                foods.Add(food);
            }
            return foods;

        }
        public Models.Restaurant SetRestaurant(Models.Restaurant _restaurant)
        {
            if (_restaurant == null) throw new ArgumentNullException();
            context.Restaurants.Add(_restaurant);
            context.SaveChanges();
            return _restaurant;
        }

        public Food SetFood(Food _food)
        {
            if (_food == null) throw new ArgumentNullException();
            context.Foods.Add(_food);
            context.SaveChanges();
            return _food;
        }


    }
}
