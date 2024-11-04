using Microsoft.EntityFrameworkCore;
using rza_project.Models;

namespace rza_project.Services
{
    public class CustomerService
    {
        private readonly TlS2302758RzaContext _context;
        public CustomerService(TlS2302758RzaContext context)
        {
            _context = context;
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }
        public async Task<Customer> LogIn(Customer customer)
        {
            return await _context.Customers.FirstOrDefaultAsync(
                c => c.Username == customer.Username &&
                c.Password == customer.Password);
        }


    }
}