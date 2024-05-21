using AppointAPI.Models;

namespace AppointAPI.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(string id);
        Task<bool> CreateCustomerAsync(Customer Customer);
        Task<bool> UpdateCustomerAsync(Customer Customer);
        Task<bool> DeleteCustomerAsync(string id);
    }
}
