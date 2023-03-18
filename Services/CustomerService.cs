﻿using AutoMapper;
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
    }
}
