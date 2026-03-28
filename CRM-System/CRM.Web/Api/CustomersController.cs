using CRM.Web.Data;
using CRM.Web.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRM.Web.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        //Define Context
        private readonly CRMDbContext _context;
        //Add COnstructor
        public CustomersController(CRMDbContext context)
        {
            _context = context;
        }

        // GET: api/<CustomersController>
        [HttpGet]
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        // POST: api/<CustomersController>
        [HttpPost]
        public IActionResult CreateCustomer(Customer customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return Ok("Successfully Added " + customer);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(Customer customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }

            //Check if the customer exists in the database
            var existingCustomer = _context.Customers.Find(customer.Id);
            if (existingCustomer == null)
            {
                return NotFound();
            }

            existingCustomer.FirstName = customer.FirstName;
            existingCustomer.LastName = customer.LastName;
            existingCustomer.UserName = customer.UserName;
            existingCustomer.Balance = customer.Balance;

            _context.SaveChanges();
            return Ok("Successfully Updated " + existingCustomer);

        }
    }
}
