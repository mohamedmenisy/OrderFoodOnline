using RestaurantApi.Context;
using RestaurantApi.Interfaces;
using RestaurantApi.Models;

namespace RestaurantApi.Repositories
{
    public class CustomerRepo:ICustomer
    {
        private readonly RestaurantContext db;

        public CustomerRepo(RestaurantContext _db)
        {
            db = _db;
        }
        public Customer SetCustomer(Customer _customer)
        {
            if (_customer == null) throw new ArgumentNullException();
            
            db.Customers.Add(_customer);
            db.SaveChanges();
            return _customer;
        }
    }
}
