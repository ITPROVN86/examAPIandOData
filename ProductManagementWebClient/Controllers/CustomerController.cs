using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Services;
using ShopDTO;

namespace ProductManagementWebClient.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        // GET: CategoryController
        public async Task<ActionResult> Index()
        {
            var category = await _customerService.GetCustomers();
            return View(category);
            //return View();
        }

        // GET: CategoryController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var category = await _customerService.GetCustomerById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CustomerDTO customer)
        {
            if (ModelState.IsValid)
            {
                await _customerService.Create(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: CategoryController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var category = await _customerService.GetCustomerById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, CustomerDTO customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _customerService.Update(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: CategoryController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var category = await _customerService.GetCustomerById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, CustomerDTO customer)
        {
            try
            {
                await _customerService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(customer);
            }
        }
    }
}
