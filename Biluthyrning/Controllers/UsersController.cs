﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biluthyrning.Data;
using Biluthyrning.Models;
using Biluthyrning.ViewModels;
using Microsoft.Extensions.Hosting;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;

namespace Biluthyrning.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUser userRepository;
        private readonly ICar carRepository;
        private readonly IBooking bookingRepository;

        public UsersController(IUser userRepository, ICar carRepository, IBooking bookingRepository)
        {
            this.userRepository = userRepository;
            this.carRepository = carRepository;
            this.bookingRepository = bookingRepository;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return userRepository != null ?
                        View(await userRepository.GetAllAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Users'  is null.");
        }
        // GET: Users/UserView
        public async Task<IActionResult> UserView()
        {
            ViewBag.Users = new SelectList(await userRepository.GetAllAsync(), "UserId", "FirstName");


            return View();

        }


        //GET:Users/AdminLista
        public async Task<IActionResult> AdminView()
        {
                return View();
        }

        //GET:Users/UserCreate
        public async Task<IActionResult> UserCreate()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserCreate([Bind("UserId,Blacklist,IsAdmin,FirstName,LastName,Email,PhoneNumber")] User user)
        {
            if (ModelState.IsValid)
            {
                await userRepository.CreateAsync(user);

                return RedirectToAction("UserView");
            }
            return View(user);
        }

        //GET:Users/AdminLista
        public async Task<IActionResult> AdminLista()
        {
            var hej = await bookingRepository.GetAllAsync();
            var car = new List<RentedCarsViewModel>();
            foreach (var item in hej)
            {
                var c = new RentedCarsViewModel();
                c.CarId = item.CarId;
                c.Booking = await bookingRepository.GetByCarIdAsync(c.CarId);
                var x=carRepository.GetByIdAsync(item.CarId).Result.Name;
                c.Name = x;
                c.Start = item.Start;
                c.End = item.End;
                c.FirstName = userRepository.GetByIdAsync(item.UserId).Result.FirstName;
                c.LastName = userRepository.GetByIdAsync(item.UserId).Result.LastName;
                car.Add(c);
            }
            return View(car);
        }

        //GET: Users/AdminListaFiltered
        public async Task<IActionResult> AdminListaFiltered(DateTime startDate, DateTime endDate)
        {
            var car = new List<RentedCarsViewModel>();
            foreach (var item in await bookingRepository.GetAllAsync())
            {
                if ((startDate >= item.Start && startDate <= item.End) || (endDate >= item.Start && endDate <= item.End))
                {
                    if (endDate >= item.Start)
                    {
                        var c = new RentedCarsViewModel();
                        c.CarId = item.CarId;
                        c.Start = item.Start;
                        c.End = item.End;
                        c.FirstName = userRepository.GetByIdAsync(item.UserId).Result.FirstName;
                        c.LastName = userRepository.GetByIdAsync(item.UserId).Result.LastName;
                        car.Add(c);
                    }
                }
            }
            return View(car);
        }

        //GET: Users/DetailsAdminView
        public async Task<IActionResult> DetailsAdminView(int id)
        {
            return View(await userRepository.GetByIdAsync(id));
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var userscar = new List<DetailsUserViewModel>();
            foreach (var item in await bookingRepository.GetByUserIdAsync(id))
            {
                var c = new DetailsUserViewModel();
                c.Booking = item;
                c.Car = await carRepository.GetByIdAsync(item.CarId);
                c.User = await userRepository.GetByIdAsync(item.UserId);
               
                userscar.Add(c);
            }
            //ViewBag.UserDetails=  (await userRepository.GetAllAsync(), "UserId", "FirstName", "LastName", "Email", "PhoneNumber");
            return View(userscar);
        }

        // GET: Users/DetailsViewUser/5
        public async Task<IActionResult> DetailsViewUser(int userid, int id)
        {
            if (userid == null || userRepository == null)
            {
                return NotFound();
            }
            if (userid > id)
            {
                id = userid;
            }
            if (id > userid)
            {
                userid = id;
            }
            var user = await userRepository
                .GetByIdAsync(userid);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,Blacklist,IsAdmin,FirstName,LastName,Email,PhoneNumber")] User user)
        {
            if (ModelState.IsValid)
            {
                await userRepository.CreateAsync(user);

                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || userRepository == null)
            {
                return NotFound();
            }

            var user = await userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // GET: Users/EditViewUser/5
        public async Task<IActionResult> EditViewUser(int id)
        {
            if (id == null || userRepository == null)
            {
                return NotFound();
            }

            var user = await userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

    

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,Blacklist,IsAdmin,FirstName,LastName,Email,PhoneNumber")] User user)
        {
            if (id != user.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await userRepository.UpdateAsync(user);

                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }
        // POST: Users/EditViewUser/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditViewUser(int id, [Bind("UserId,Blacklist,IsAdmin,FirstName,LastName,Email,PhoneNumber")] User user)
        {
            if (id != user.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await userRepository.UpdateAsync(user);
                
                TempData["successMessage"] = "Din information har sparats";
                return RedirectToAction("EditViewUser");
            }
            return View(user);
        }
        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || userRepository == null)
            {
                return NotFound();
            }

            var user = await userRepository
                .GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (userRepository == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Users'  is null.");
            }
            var user = await userRepository.GetByIdAsync(id);
            if (user != null)
            {
                await userRepository.DeleteAsync(id);
            }

            //await userRepository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
