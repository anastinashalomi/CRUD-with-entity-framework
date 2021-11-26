using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUDApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDApplication.Controllers
{
    public class CustomerController : Controller
    {

        private readonly ApplicationDbContext _db;

        public CustomerController(ApplicationDbContext db)
        {
            _db=db;
        }

        //index page function for retrive data from database to view
        public IActionResult Index()
        {
            var displaydata = _db.customer.ToList();
            return View(displaydata);
        }


        //create customer function
        public IActionResult Create()
        {
            return View();
        }

        //create post method
        [HttpPost]
        public async Task<IActionResult> Create(NewCusClass cus)
        {
            if (ModelState.IsValid)
            {
                _db.Add(cus);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cus);
        }


        //method for edit customer
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var getcusdetails = await _db.customer.FindAsync(id);
            return View(getcusdetails);

        }

        // post method for edit customer
        [HttpPost]
        public async Task<IActionResult> Edit(NewCusClass nc)
        {
            if (ModelState.IsValid)
            {
                _db.Update(nc);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(nc);
        }

        // method for details customer
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var getcusdetails = await _db.customer.FindAsync(id);
            return View(getcusdetails);

        }

        // method for update 
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var getcusdetails = await _db.customer.FindAsync(id);
            return View(getcusdetails);

        }

        // post method for delete customer
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var getcusdetails = await _db.customer.FindAsync(id);
            _db.customer.Remove(getcusdetails);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");

        }

    }
}