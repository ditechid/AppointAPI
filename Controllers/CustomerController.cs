using AppointAPI.Models;
using AppointAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AppointAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _repository;

        public CustomerController(ICustomerRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            var Customers = await _repository.GetAllCustomersAsync();
            return Ok(Customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(string id)
        {
            var Customer = await _repository.GetCustomerByIdAsync(id);
            if (Customer == null)
            {
                return NotFound();
            }
            return Ok(Customer);
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomer(Customer Customer)
        {
            bool inserted = await _repository.CreateCustomerAsync(Customer);
            if (!inserted)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(string id, Customer Customer)
        {
            if (id != Customer.Id)
            {
                return BadRequest();
            }

            bool updated = await _repository.UpdateCustomerAsync(Customer);
            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(string id)
        {
            bool deleted = await _repository.DeleteCustomerAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
