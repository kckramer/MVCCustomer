using MVCCustomer.Entities;
using MVCCustomer.Services;

using Microsoft.AspNetCore.Mvc;
using MVCCustomer.ViewModels;
using System.Linq;
using System;

namespace MVCCustomer.Controllers
{
    public class CustomerController : Controller
    {
        public ICustomerData _customerData;

        public CustomerController(ICustomerData customerData)
        {
            _customerData = customerData;
        }

        public ViewResult Index()
        {
            var model = new CustomerViewModel();
            model.Customers = _customerData.GetAll();

            return View(model);
        }

        //public ViewResult Index(string errorMessage)
        //{
        //    var model = new CustomerViewModel();
        //    model.Customers = _customerData.GetAll();

        //    return View(model);
        //}

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _customerData.Get(id);

            if (model == null)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        } 

        [HttpPost]
        public IActionResult Edit(int id, CustomerEditViewModel input)
        {
            var customer = _customerData.Get(id);

            if (customer != null && ModelState.IsValid)
            {
                customer.FirstName = input.FirstName;
                customer.LastName = input.LastName;
                customer.Email = input.Email;
                customer.FavoriteColor = input.FavoriteColor;

                _customerData.Commit();

                return RedirectToAction("Details", new { id = customer.Id });
            }

            return View(customer);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CustomerEditViewModel model)
        {
            var result = TryValidateModel(model);

            if (ModelState.IsValid)
            {
                var customer = new Customer();
                customer.FirstName = model.FirstName;
                customer.LastName = model.LastName;
                customer.Email = model.Email;
                customer.FavoriteColor = model.FavoriteColor;
                
                if (_customerData.Add(customer) == false)
                {

                    return View("ErrorEmail", customer);
                }

                _customerData.Commit();

                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Details(int id)
        {
            var model = _customerData.Get(id);

            if (model == null)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
