using laptrinhweb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace laptrinhweb.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        public ActionResult Index(string search = "", string sort="", int page = 1)
        {
            CompanyDBContext db = new CompanyDBContext();
            List<SanPham> sanPhams = db.SanPhams.Where(row=>row.Name.Contains(search)).ToList();
            switch (sort)
            {

                case "tang":
                    sanPhams = sanPhams.OrderBy(row => row.Price).ToList();
                    break;
                case "giam":
                    sanPhams = sanPhams.OrderByDescending(row => row.Price).ToList();
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
        public ActionResult LocThuongHieu(int id)
        {
            CompanyDBContext db = new CompanyDBContext();
            List<SanPham> sanPhams = db.SanPhams.Where(row => row.ThuongHieuId == id).ToList();
            ViewBag.ThuongHieu = db.ThuongHieus.Where(row => row.ThuongHieuId == id).FirstOrDefault();
            return View(sanPhams);

        }
        public ActionResult LocChuDe(int id)
        {
            CompanyDBContext db = new CompanyDBContext();
            List<SanPham> sanPhams = db.SanPhams.Where(row => row.ChuDeId == id).ToList();
            ViewBag.ChuDe = db.ChuDes.Where(row => row.ChuDeId == id).FirstOrDefault();
            return View(sanPhams);

        }
        public ActionResult ChiTietSanPham(int id)
        {
            CompanyDBContext db = new CompanyDBContext();
            SanPham sanPham = db.SanPhams.Where(row => row.SanPhamId == id).FirstOrDefault();
            return View(sanPham);
        }
    }
}