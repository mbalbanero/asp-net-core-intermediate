using CRM.Web.Data;
using CRM.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CRM.Web.Controllers
{
    public class CustomersController : Controller
    {
        //Define Context
        private readonly CRMDbContext _context;

        //Add Constructor
        public CustomersController(CRMDbContext context)
        {
            _context = context;
        }

        //Read Customer List
        public IActionResult Index()
        {
            //Display Customers
            var customers = _context.Customers.ToList();
            return View(customers);
        }

        [HttpGet]
        //Create Customer Entry
        public IActionResult Create()
        {
            return View();
        }

        //Submit Input for Create Customer Entry
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                //INSERT
                _context.Add(customer);


                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);

        }

        //EDIT
        [HttpGet]
        //Create Customer Entry
        public IActionResult Edit(int id)
        {
            //Check if exists
            var customer = _context.Customers.Find(id);

            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                ViewData["UserName"] = customer.UserName;
                ViewData["FirstName"] = customer.FirstName;
                ViewData["LastName"] = customer.LastName;
                ViewData["Balance"] = customer.Balance;
            }

            return View();
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                //INSERT
                _context.Update(customer);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);

        }

        [HttpGet]
        //Create Customer Entry
        public IActionResult Delete(int id)
        {
            //Check if exists
            var customer = _context.Customers.Find(id);

            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                ViewData["UserName"] = customer.UserName;
                ViewData["FirstName"] = customer.FirstName;
                ViewData["LastName"] = customer.LastName;
                ViewData["Balance"] = customer.Balance;
            }

            return View(customer);
        }

        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            
            var customerFound = _context.Customers.Find(customer.Id);

            if (customerFound == null)
            {
                return NotFound();
            }
            else
            {
                //Remove Customer if found
                _context.Customers.Remove(customerFound);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
