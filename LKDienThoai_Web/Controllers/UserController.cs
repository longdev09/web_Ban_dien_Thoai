using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LKDienThoai_Web.Models;
namespace LKDienThoai_Web.Controllers
{
    public class UserController : Controller
    {
            
        //
        // GET: /User/
        DuLieu_LkDTDataContext dl = new DuLieu_LkDTDataContext();
        public ActionResult taiKhoan()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangKy(FormCollection dk)
        {
            TAIKHOAN tks = dl.TAIKHOANs.FirstOrDefault(t => t.TENDANGNHAP == dk["Email"]);
            TAIKHOAN tk = new TAIKHOAN();
            KhachHang kh = new KhachHang();
            if (tks == null)
            {
                tk.TENDANGNHAP = dk["Email"];
                tk.MATKHAU = dk["Password"];
                tk.LOAITAIKHOAN = "USER";
                kh.MaKH = "";
                kh.HoTen = dk["Name"];
                kh.TENDANGNHAP = dk["Email"];
                dl.TAIKHOANs.InsertOnSubmit(tk);
                dl.KhachHangs.InsertOnSubmit(kh);
            }
            dl.SubmitChanges();
            return RedirectToAction("taiKhoan", "User");
        }


        [HttpPost]
        public ActionResult DangNhap(FormCollection dn)
        {
            TAIKHOAN tkdn = dl.TAIKHOANs.FirstOrDefault(t => t.TENDANGNHAP == dn["tdn"] && t.MATKHAU == dn["mk"]);
            if(tkdn != null)
            {
                KhachHang kh = dl.KhachHangs.FirstOrDefault(t => t.TENDANGNHAP == tkdn.TENDANGNHAP);
                Session["khName"] = kh;
            }
            
            if(tkdn != null)
            {
                Session["tkdn"] = tkdn;
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("taiKhoan", "User");
        }
        public ActionResult DangXuat()
        {
            Session.Clear();
            return RedirectToAction("Index","Home");
        }

        public ActionResult CapNhat()
        {
            return View();
        }
        [HttpPost]
        public ActionResult xlCn(FormCollection f)
        {
            KhachHang kh = (KhachHang)Session["khName"];
            KhachHang a = new KhachHang();
            a = dl.KhachHangs.FirstOrDefault(t => t.MaKH == kh.MaKH);
            a.HoTen = f["ht"];
            a.DienThoai = f["dt"];
            a.DiaChi = f["dc"];
            a.NgaySinh = DateTime.Parse(f["sn"].ToString());
            a.gioiTinh = f["fav_language"];
            dl.SubmitChanges();
            return RedirectToAction("Index","Home");
        }
    }
}
 