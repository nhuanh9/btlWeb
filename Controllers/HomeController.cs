using BTL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL.Controllers
{
    public class HomeController : Controller
    {
        MobileStoreManagementEntities db = new MobileStoreManagementEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View(db.SanPhams.ToList());
        }

        [HttpGet]
        public ActionResult blog()
        {
            return View();
        }

        [HttpGet]
        public ActionResult single()
        {
            return View();
        }
        public ActionResult contact()
        {
            return View();
        }
        public PartialViewResult News()
        {
            List<SanPham> sanPhams = db.SanPhams.ToList();
            return PartialView(sanPhams);
        }
        public PartialViewResult topSale()
        {
            List<SanPham> sanPhams = db.SanPhams.ToList();
            return PartialView(sanPhams);
        }

        public PartialViewResult Tags()
        {
            List<HangSX> hangSXes = db.HangSXes.ToList();
            return PartialView(hangSXes);
        }

        public ViewResult sanPhamTheoHang(string MaHSX = "SSU")
        {
            HangSX hangSX = db.HangSXes.SingleOrDefault(n => n.MaHSX == MaHSX);
            if (hangSX == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<SanPham> lstSanPham = db.SanPhams.Where(n => n.MaHSX == MaHSX).OrderBy(n => n.MaHSX).ToList();
            if (lstSanPham.Count == 0)
            {
                ViewBag.SanPham = "Không có sản phẩm nào!";
            }
            ViewBag.lstSanPham = db.SanPhams.ToList();
            return View(lstSanPham);
        }
        public ViewResult xemChiTiet(int MaSP = 1)
        {
            SanPham sanPham = db.SanPhams.SingleOrDefault(n => n.MaSP == MaSP);
            if (sanPham == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sanPham);

        }

        public ActionResult Xoa(int MaSP = 1)
        {
            SanPham sanPham = db.SanPhams.SingleOrDefault(n => n.MaSP == MaSP);
            if (sanPham == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sanPham);
        }

        [HttpPost, ActionName("Xoa")]
        public ActionResult XacNhanXoa(int MaSP)
        {
            SanPham sanPham = db.SanPhams.SingleOrDefault(n => n.MaSP == MaSP);
            if (sanPham == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            
            db.SanPhams.Remove(sanPham);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult themSanPham()
        {
            ViewBag.MaHSX = new SelectList(db.HangSXes.ToList().OrderBy(n => n.TenHSX), "MaHSX", "TenHSX");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult ThemSanPham([Bind(Include = "MaSP, TenSP, MaHSX, DonGiaNhap, DonGiaBan, SoLuong")] SanPham sanpham)
        {
            if (ModelState.IsValid)
            {
                db.SanPhams.Add(sanpham);
                db.SaveChanges();
                return RedirectToAction("Index");            
            }
            return View(sanpham);
        }

        [HttpGet]
        public ActionResult chinhSua(int MaSP)
        {
            ViewBag.MaHSX = new SelectList(db.HangSXes.ToList().OrderBy(n => n.TenHSX), "MaHSX", "TenHSX");

            if (MaSP == null)
            {
                return new HttpStatusCodeResult
                    (System.Net.HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(MaSP);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult chinhSua([Bind(Include = "MaSP, TenSP, MaHSX, DonGiaNhap, DonGiaBan, SoLuong")] SanPham sanpham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanpham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            return RedirectToAction("Index");
        }

        public PartialViewResult list(int opt = 1)
        {
            if (opt == 1)
            {
                return PartialView(db.SanPhams.OrderBy(n => n.TenSP).ToList());
            }
            else
            {
                return PartialView(db.SanPhams.OrderBy(n => n.DonGiaBan).ToList());
            }
           
        }
    }
}