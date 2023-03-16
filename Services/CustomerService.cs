using Microsoft.EntityFrameworkCore;
using TheShoesShop_BackEnd.Models;

namespace TheShoesShop_BackEnd.Services
{
    public class CustomerService
    {
        private readonly TheShoesShopDbContext _context;

        public CustomerService(TheShoesShopDbContext context) 
        {
            _context = context;
        }

        public List<customer> GetAllCustomer()
        {
            var customers = _context.customer.ToList();
            return customers;
        }

        public customer? GetCustomerById(int ID)
        {
            var customer = _context.customer.SingleOrDefault(customer => customer.CustomerID == ID);
            return customer;
        }

        public customer? GetCustomerByEmail(string? Email)
        {
            var customer = _context.customer.SingleOrDefault(customer => customer.Email.Equals(Email));
            return customer;
        }
    }
}
