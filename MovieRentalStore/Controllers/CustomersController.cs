using MovieRentalStore.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieRentalStore.Migrations;
using MovieRentalStore.ViewModels;

namespace MovieRentalStore.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if(!ModelState.IsValid)
            {

                var ViewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()



                };

                return View("CustomerForm", ViewModel);
            }


            if(customer.Id == 0)
               _context.Customers.Add(customer);
           
                
            else
            {
                var CustomerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                CustomerInDb.Name = customer.Name;
                CustomerInDb.Birthdate = customer.Birthdate;
                CustomerInDb.MembershipTypeId = customer.MembershipTypeId;
                CustomerInDb.IsSubscribeToNewsLetter = customer.IsSubscribeToNewsLetter;

            }
            _context.SaveChanges();
            return RedirectToAction("Index","Customers");
        }


        public ViewResult Index()
        {
            return View();
        }

      
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            

            if (customer == null)
                return HttpNotFound();
            var ViewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes =_context.MembershipTypes.ToList()


             
            };

            return View("CustomerForm", ViewModel);
        }


    }
}