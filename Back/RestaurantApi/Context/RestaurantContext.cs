using Microsoft.EntityFrameworkCore;
using RestaurantApi.Models;
using System.Collections.Generic;

namespace RestaurantApi.Context
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext()
        {

        }
        public RestaurantContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
