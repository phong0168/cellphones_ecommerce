using laptrinhweb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Web.UI;

namespace laptrinhweb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            CompanyDBContext db = new CompanyDBContext();
            List<SanPham> sanPhams = db.SanPhams.Where(row => row.ChuDeId == 3).ToList();
            return View(sanPhams);
        }
        public ActionResult Error404()
        {
            return View();
        }

    }
}