using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using laptrinhweb.Filters;
using laptrinhweb.Models;

namespace laptrinhweb.Controllers
{
    public class GioHangController : Controller
    {
       
        // GET: GioHang
        public ActionResult ThemGioHang(int id)
        {
            CompanyDBContext db = new CompanyDBContext();
            SanPham sanPham = db.SanPhams.SingleOrDefault(row => row.SanPhamId == id);
            if(sanPham != null)
            {
                GetCart().Add(sanPham);
            }
            return RedirectToAction("HienThiGioHang", "GioHang");

        }
        public GioHang GetCart()
        {
            GioHang gioHang = Session["GioHang"] as GioHang;
            if(gioHang == null || Session["GioHang"] == null)
            {
                gioHang = new GioHang();
                Session["GioHang"] = gioHang;
            }
            return gioHang;
        }
        [AuthenFilter]
        public ActionResult HienThiGioHang()
        {
            if (Session["GioHang"] == null)
                return RedirectToAction("GioHangTrong", "GioHang");    
            GioHang gioHang = Session["GioHang"] as GioHang;
            return View(gioHang);
            
        }
        public ActionResult ThanhToan()
        {
            if (Session["GioHang"] == null)
                return RedirectToAction("GioHangTrong", "GioHang");
            GioHang gioHang = Session["GioHang"] as GioHang;
            return View(gioHang);
        }
        [HttpPost]
        public ActionResult ThanhToan(DatHang dh)
        {
            CompanyDBContext db = new CompanyDBContext();
            db.DatHangs.Add(dh);
            db.SaveChanges();
            return RedirectToAction("DatHangThanhCong","GioHang");
        }
        public ActionResult DatHangThanhCong()
        {
            return View();
        }


        public ActionResult GioHangTrong()
        {
            return View();
        }
        public ActionResult UpdateSL(FormCollection form)
        {
            GioHang gioHang = Session["GioHang"] as GioHang;
            int id = int.Parse(form["SanPhamId"]);
            int sl = int.Parse(form["SoLuong"]);
            gioHang.Update(id, sl);
            return RedirectToAction("HienThiGioHang", "GioHang");

        }
        public ActionResult Delete(int id)
        {
            GioHang gioHang = Session["GioHang"] as GioHang;
            gioHang.Remove(id);
            return RedirectToAction("HienThiGioHang", "GioHang");

        }
    }

}