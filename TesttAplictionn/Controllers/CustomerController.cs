using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesttAplictionn.Interface;
using TesttAplictionn.Models;

namespace TesttAplictionn.Controllers
{
    public class CustomerController : Controller
    {
        // GET: CustomerController

        private readonly ICustomerRepository _customerRepository;



        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;

        }


        public ActionResult Index()
        {
            return View(_customerRepository.GetAllCustomer().ToList());
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View(_customerRepository.GetCustomerById(id));
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] Customer customer)
        {
            try
            {
                _customerRepository.InsertCustomer(customer);
                _customerRepository.SaveCustomer();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_customerRepository.GetCustomerById(id));
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([FromForm] Customer customer)
        {
            try
            {
                _customerRepository.UpdateCustomer(customer);
                _customerRepository.SaveCustomer();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_customerRepository.GetCustomerById(id));
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete([FromForm] Customer customer)
        {
            try
            {
                _customerRepository.DeleteCustomer(customer.CustomerId);
                _customerRepository.SaveCustomer();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
