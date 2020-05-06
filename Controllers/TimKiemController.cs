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
        public ActionResult KetQuaTimKiem(FormCollection form)
        {
            string searchKey = form["txtTimKiem"].ToString();
            List<SanPham> lstKQTK = db.SanPhams.Where(n => n.TenSP.Contains(searchKey)).ToList();
            if (lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm nào!";
                return View(db.SanPhams.ToList());
            }
            else
            {
                ViewBag.ThongBao = "Đã tìm thấy " + lstKQTK.Count() + " sản phẩm "+ searchKey;
                return View(lstKQTK.ToList());
            }
        }
    }
}