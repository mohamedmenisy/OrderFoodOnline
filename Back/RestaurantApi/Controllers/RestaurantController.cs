using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantApi.DTO;
using RestaurantApi.Interfaces;
using RestaurantApi.Models;
using RestaurantApi.Repositories;
using System.ComponentModel.DataAnnotations;

namespace RestaurantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurant restuarant;

        public RestaurantController(IRestaurant _restuarant)
        {
            restuarant = _restuarant;
        }

        [HttpGet("Search")]
        public IActionResult Get([Required]int cityId ,string? resturantName) {
        
         var restuarants=restuarant.GetRestuarants(cityId, resturantName);
            if (restuarants.Count > 0 )
            {
                return Ok(restuarants);
            }
            return BadRequest(new { message="Not Found"});

        }
        [HttpGet("Menu")]
        public IActionResult GetMenu(int restaurantId,int page) {

            var menu= restuarant.GetMenu(restaurantId);

            if (menu.Count > 0 )
            {
                List<OrderItemDTO> orderItems=new List<OrderItemDTO>();
                foreach (var item in menu)
                {
                    OrderItemDTO orderItem = new OrderItemDTO() { 
                      foodId=item.foodId,
                      foodDescription=item.foodDescription,
                       foodName=item.foodName,
                       foodPicture = item.foodPicture,
                       foodPrice = item.foodPrice,
                       quantity = 1
                    
                    
                    };
                    orderItems.Add(orderItem);

                }
                if (page < 1)
                    page = 1;
                var totalFoods = orderItems.Count;
                var totalPages = (int)Math.Ceiling(totalFoods / (double)2);
                if (page > totalPages)

                {

                    return NotFound(new  { Message = $"No Product Here Back To {totalPages} " });
                }
                var AllFoods = orderItems.Skip((page - 1) * 2).Take(2).ToList();
                return Ok(new {orederItems=AllFoods ,TotalPages=totalPages});

            }
            else
            {
                return NotFound("Not Found");
            }
        }

        [HttpPost("AddRestaurant")]
        public IActionResult AddRestaurant(RestaurantDTO2 rest)
        {

            var projectFolder = Directory.GetCurrentDirectory();
            var relativeImagesPath = Path.Combine("wwwroot", "Images");
            var fullImagesPath = Path.Combine(projectFolder, relativeImagesPath);
            var fileName = $"{Guid.NewGuid()}_{rest.RestuarantPicture.FileName}";
            var fullImagePath = Path.Combine(fullImagesPath, fileName);
            using (var stream = new FileStream(fullImagePath, FileMode.Create))
            {
                rest.RestuarantPicture.CopyTo(stream);
                stream.Flush();
            }
            var url = $"{Request.Scheme}://{Request.Host}/wwwroot/Images/{fileName}";
            Models.Restaurant myrestuarant = new Models.Restaurant()
            {
                CityId = rest.cityid,
                Description = rest.Description,
                Name = rest.RestuarantName,
                RestuarantPicture = url
            };
            var result=  restuarant.SetRestaurant(myrestuarant);
            if (result != null)
            {
                return Ok("restuarant Added");

            }
            else
            {
                return BadRequest();
            }
        }



        [HttpPost("AddFood")]
        public IActionResult AddFood(FoodDTO2 _food)
        {

            var projectFolder = Directory.GetCurrentDirectory();
            var relativeImagesPath = Path.Combine("wwwroot", "Images");
            var fullImagesPath = Path.Combine(projectFolder, relativeImagesPath);
            var fileName = $"{Guid.NewGuid()}_{_food.foodPicture.FileName}";
            var fullImagePath = Path.Combine(fullImagesPath, fileName);
            using (var stream = new FileStream(fullImagePath, FileMode.Create))
            {
                _food.foodPicture.CopyTo(stream);
                stream.Flush();
            }
            var url = $"{Request.Scheme}://{Request.Host}/wwwroot/Images/{fileName}";
            Food food = new Food()
            {
                Description = _food.foodDescription,
                Name = _food.foodName,
                Picture = url,
                Price = _food.foodPrice,
                RestuarantId=_food.Restaurantid
            };
            var result = restuarant.SetFood(food);
            if (result != null)
            {
                return Ok("Food Added");

            }
            else
            {
                return BadRequest();
            }
        }


    }
}
