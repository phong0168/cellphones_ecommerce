using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using laptrinhweb.Filters;
using laptrinhweb.Identity;
using laptrinhweb.Models;
using laptrinhweb.ViewModel;
using Microsoft.AspNet.Identity;

namespace laptrinhweb.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class UserController : Controller
    {
        // GET: Admin/User
        public ActionResult Index()
        {
            AppDbContext db = new AppDbContext();
            List<AppUser> users = db.Users.ToList();
            return View(users);
        }
        public ActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Create(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                var appDbContext = new AppDbContext();
                var userStore = new AppUserStore(appDbContext);
                var userManager = new AppUserManager(userStore);
                var passwordHash = Crypto.HashPassword(register.Password);
                var user = new AppUser()
                {
                    Email = register.Email,
                    UserName = register.UserName,
                    PasswordHash = passwordHash,
                    City = register.City,
                    Address = register.Address,
                    PhoneNumber = register.PhoneNumber
                };
                IdentityResult identityResult = userManager.Create(user);
                if (identityResult.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Customer");
                    var authenManager = HttpContext.GetOwinContext().Authentication;
                    var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                }
                return RedirectToAction("Index", "User");
            }
            else
            {
                ModelState.AddModelError("New Error", "Invalid data");
                return View();
            }

        }
        public ActionResult Delete(string id)
        {
            AppDbContext db = new AppDbContext();
            AppUser user = db.Users.Where(row => row.Id == id).FirstOrDefault();
            return View(user);

        }
        [HttpPost]
        public ActionResult Delete(string id, SanPham sp)
        {
            AppDbContext db = new AppDbContext();
            AppUser user = db.Users.Where(row => row.Id == id).FirstOrDefault();
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(string id)
        {
            AppDbContext db = new AppDbContext();
            AppUser user = db.Users.Where(row => row.Id == id).FirstOrDefault();
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(AppUser u)
        {
            AppDbContext db = new AppDbContext();
            AppUser user = db.Users.Where(row => row.Id == u.Id).FirstOrDefault();
            user.Address = u.Address;
            user.Email = u.Email;
            user.PhoneNumber = u.PhoneNumber;
            user.City = u.City;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}