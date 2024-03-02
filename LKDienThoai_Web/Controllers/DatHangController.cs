using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LKDienThoai_Web.Models;
namespace LKDienThoai_Web.Controllers
{
    public class DatHangController : Controller
    {
        DuLieu_LkDTDataContext dl = new DuLieu_LkDTDataContext();
        //
        // GET: /DatHang/

        public ActionResult DatHang()
        {
            if (Session["tkdn"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("taiKhoan", "User");
            }
            
        }
        [HttpPost]
        public ActionResult XlDatHang(FormCollection dhang)
        {
            HoaDonDat hd = new HoaDonDat();
            TAIKHOAN tk = (TAIKHOAN)Session["tkdn"];
            KhachHang kh = dl.KhachHangs.FirstOrDefault(t => t.TENDANGNHAP == tk.TENDANGNHAP);
            GioHang gio = (GioHang)Session["CART"];
            hd.MaHDDH = "";
            hd.DonGia = gio.TongTien();
            hd.NgayDat = DateTime.Now;
            hd.DiaChiNhanHang = dhang["diaChi"];
            hd.PTVanChuyen = dhang["ptVc"];
            hd.PTThanhToan = dhang["PtTT"];
            hd.MaKH = kh.MaKH;
            hd.TinhTrangGiao = "Đang chờ xử lý";
            dl.HoaDonDats.InsertOnSubmit(hd);
            dl.SubmitChanges();
            gio.XoaH();
            Session["CART"] = gio;
            return RedirectToAction("Index", "Home");
        }

    }
}
