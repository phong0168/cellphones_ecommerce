using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using laptrinhweb.Filters;
using laptrinhweb.Models;

namespace laptrinhweb.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class DonDatHangController : Controller
    {
        // GET: Admin/DonDatHang
        public ActionResult Index()
        {
            CompanyDBContext db = new CompanyDBContext();
            var donHangs = db.DatHangs.ToList();
            return View(donHangs);
        }
        public ActionResult Detail(int id)
        {
            CompanyDBContext db = new CompanyDBContext();
            var donHang = db.DatHangs.Where(row=>row.Id == id).FirstOrDefault();
            return View(donHang);
        }

    }
}