using BTL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
namespace BTL.Controllers
{
    public class TimKiemController : Controller
    {
        MobileStoreManagementEntities db = new MobileStoreManagementEntities();
        // GET: TimKiem
        public ActionResult KetQuaTimKiem(FormCollection form, int? page)
        {
            int pageSize = 100;
            int pageNumber = (page ?? 1);
            string searchKey = form["txtTimKiem"].ToString();
            ViewBag.form = form;
            List<SanPham> lstKQTK = db.SanPhams.Where(n => n.TenSP.Contains(searchKey)).ToList();
            if (lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm nào!";
                return View(db.SanPhams.ToList().ToPagedList(pageNumber, pageSize));
            }
            else
            {
                ViewBag.ThongBao = "Đã tìm thấy " + lstKQTK.Count() + " sản Phẩm "+searchKey;
                return View(lstKQTK.ToList().ToPagedList(pageNumber, pageSize));
            }
        }
    }
}