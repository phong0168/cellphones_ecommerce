using laptrinhweb.Filters;
using laptrinhweb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Web.UI;

namespace laptrinhweb.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class SanPhamController : Controller
    {
        // GET: Admin/SanPham
        public ActionResult Index(string search = "", string sort = "", int page = 1)
        {
            CompanyDBContext db = new CompanyDBContext();
            List<SanPham> sanPhams = db.SanPhams.Where(row => row.Name.Contains(search)).ToList();
            switch (sort)
            {

                case "tang":
                    sanPhams = sanPhams.OrderBy(row => row.Price).ToList();
                    break;
                case "giam":
                    sanPhams = sanPhams.OrderByDescending(row => row.Price).ToList();
                    break;
                case "idgiam":
                    sanPhams = sanPhams.OrderByDescending(row => row.SanPhamId).ToList();
                    break;
                case "idtang":
                    sanPhams = sanPhams.OrderBy(row => row.SanPhamId).ToList();
                    break;

            }
            ViewBag.search = search;
            int noOfRecordPerPage = 4;
            int noOfPage = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(sanPhams.Count) / Convert.ToDouble(noOfRecordPerPage)));
            int noOfRecordToSkip = (page - 1) * noOfRecordPerPage;
            sanPhams = sanPhams.Skip(noOfRecordToSkip).Take(noOfRecordPerPage).ToList();
            ViewBag.noOfPage = noOfPage;
            ViewBag.sort = sort;
            return View(sanPhams);
        }
        public ActionResult Create()
        {
            CompanyDBContext db = new CompanyDBContext();
            ViewBag.thuongHieus = db.ThuongHieus.ToList();
            ViewBag.chuDes = db.ChuDes.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(SanPham sp)
        {
            CompanyDBContext db = new CompanyDBContext();
            db.SanPhams.Add(sp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            CompanyDBContext db = new CompanyDBContext();
            SanPham sanPham = db.SanPhams.Where(row => row.SanPhamId == id).FirstOrDefault();
            ViewBag.thuongHieus = db.ThuongHieus.ToList();
            ViewBag.chuDes = db.ChuDes.ToList();
            return View(sanPham);
        }

        [HttpPost]
        public ActionResult Edit(SanPham sp)
        {
            CompanyDBContext db = new CompanyDBContext();
            SanPham sanPham = db.SanPhams.Where(row => row.SanPhamId == sp.SanPhamId).FirstOrDefault();
            sanPham.Name = sp.Name;
            sanPham.Price = sp.Price;
            sanPham.Description = sp.Description;
            sanPham.ImageUrl = sp.ImageUrl;
            sanPham.ThuongHieuId = sp.ThuongHieuId;
            sanPham.ChuDeId = sp.ChuDeId;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Delete(int id)
        {
            CompanyDBContext db = new CompanyDBContext();
            SanPham sanPham = db.SanPhams.Where(row => row.SanPhamId == id).FirstOrDefault();
            return View(sanPham);

        }
        [HttpPost]
        public ActionResult Delete(int id, SanPham sp)
        {
            CompanyDBContext db = new CompanyDBContext();
            SanPham sanPham = db.SanPhams.Where(row => row.SanPhamId == id).FirstOrDefault();
            db.SanPhams.Remove(sanPham);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult ApiGet()
        {
            CompanyDBContext db = new CompanyDBContext();
            List<SanPham> sanPhams = db.SanPhams.ToList();
            return View(sanPhams);
        }

    }
}