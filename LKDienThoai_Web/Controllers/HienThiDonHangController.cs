using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LKDienThoai_Web.Models;
namespace LKDienThoai_Web.Controllers
{
    public class HienThiDonHangController : Controller
    {
        //
        // GET: /HienThiDonHang/
        DuLieu_LkDTDataContext dl = new DuLieu_LkDTDataContext();
        public ActionResult HoaDonKh(string maKh)
        {
            List<HoaDonDat> hd = dl.HoaDonDats.Where(t => t.MaKH == maKh).ToList();
            return View(hd);
        }

    }
}
