using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantApi.Context;
using RestaurantApi.DTO;
using RestaurantApi.Models;

namespace RestaurantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly RestaurantContext restaurant;

        public OrderController(RestaurantContext _restaurant)
        {
            restaurant = _restaurant;
        }
        [HttpPost]
        public IActionResult CreateOrder(OrderDTO order)
        {
            Customer customer = new Customer() { 
                Name=order.Customer.name,
                Address=order.Customer.address,
                 Email=order.Customer.email,
                 Phone=order.Customer.phone,
            };
            restaurant.Customers.Add(customer);
            restaurant.SaveChanges();
            Order myorder = new Order();
            myorder.CustomerId = customer.Id;
            myorder.OrderDate = DateTime.Now;
            myorder.TotalPrice = order.TotalPrice;
            restaurant.Orders.Add(myorder);
            restaurant.SaveChanges();
            foreach (var item in order.orderItems)
            {
                var orderItem = new OrderItems()
                {
                    OrderId = myorder.OrderId,
                    OrderItemName = item.foodName,
                    Price = item.foodPrice,
                    OrderItemPicture = item.foodPicture,
                    Quantity = item.quantity,
                    
                };

                restaurant.OrderItems.Add(orderItem);
            }
            restaurant.SaveChanges();
                


            return Ok(new { yourOrder= order  , message = $"success please wait for {DateTime.Now.AddHours(1)}"});
        }
    }
}
