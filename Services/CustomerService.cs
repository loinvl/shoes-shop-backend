using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TheShoesShop_BackEnd.DTOs;
using TheShoesShop_BackEnd.Models;
using BC = BCrypt.Net.BCrypt;

namespace TheShoesShop_BackEnd.Services
{
    public class CustomerService
    {
        private readonly TheShoesShopDbContext _context;
        private readonly IMapper _mapper;

        public CustomerService(TheShoesShopDbContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        public List<customer> GetAllCustomer()
        {
            var CustomerList = _context.customer.ToList();
            return CustomerList;
        }

        public customer? GetCustomerById(int ID)
        {
            var Customer = _context.customer.SingleOrDefault(customer => customer.CustomerID == ID);
            return Customer;
        }

        public customer? GetCustomerByEmail(string? Email)
        {
            var Customer = _context.customer.SingleOrDefault(customer => customer.Email.Equals(Email));
            return Customer;
        }

        public customer RegisterCustomer(customer Customer)
        {
            var NewCustomer = _context.customer.Add(Customer).Entity;
            _context.SaveChanges();

            return NewCustomer;
        }

        public async Task<bool> ResetPassword(int CustomerID, string? NewPassword)
        {
            var NewHashPassword = BC.HashPassword(NewPassword);
            var Customer = await _context.customer.SingleOrDefaultAsync(ctm => ctm.CustomerID == CustomerID);
            
            if (Customer == null) { return false; }

            Customer.HashPassword = NewHashPassword;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<CustomerDTO> GetProfileByID(int? CustomerID)
        {
            var CustomerEntity = await _context.customer.SingleOrDefaultAsync(c => c.CustomerID == CustomerID);
            var Profile = _mapper.Map<CustomerDTO>(CustomerEntity);

            return Profile;
        }

        public async Task<CustomerDTO> UpdateProfileByID(CustomerDTO Profile)
        {
            var CustomerEntity = await _context.customer.SingleOrDefaultAsync(c => c.CustomerID == Profile.CustomerID);
            
            // Update if exist
            if(CustomerEntity != null)
            {
                CustomerEntity.CustomerName = Profile.CustomerName;
                CustomerEntity.Address = Profile.Address;
                CustomerEntity.Phone = Profile.Phone;
                await _context.SaveChangesAsync();
            }

            var NewProfile = _mapper.Map<CustomerDTO>(CustomerEntity);

            return NewProfile;
        }
    }
}
