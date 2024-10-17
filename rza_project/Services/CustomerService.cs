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


    }
}