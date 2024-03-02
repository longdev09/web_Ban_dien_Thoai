using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LKDienThoai_Web.Models;
namespace LKDienThoai_Web.Controllers
{
    public class  AdminController : Controller
    {
        //
        // GET: /Admin/
        DuLieu_LkDTDataContext dl = new DuLieu_LkDTDataContext();
        public ActionResult HomeAdmin()
        {
            return View();
        }

        public ActionResult Ql_KhachHang()
        {
            List<KhachHang> ql_Kh = dl.KhachHangs.ToList();
            return View(ql_Kh);
        }
        public ActionResult Ql_Hd()
        {
            List<HoaDonDat> ql_hd = dl.HoaDonDats.ToList();
            return View(ql_hd);
        }
        public ActionResult QlSanPham()
        {
            List<LinhKien> ql_Lk = dl.LinhKiens.ToList();
            return View(ql_Lk);
        }
        public ActionResult Ql_LoaiLK()
        {
           
            List<LoaiLK> qlLK = dl.LoaiLKs.ToList();
            return View(qlLK);
        }
        [HttpPost]
        public ActionResult XlThemLLK(FormCollection a)
        {
            LoaiLK ll = new LoaiLK();
            ll.MaLoai = "";
            ll.TenLoai = a["tLk"];
            dl.LoaiLKs.InsertOnSubmit(ll);
            dl.SubmitChanges();
            return RedirectToAction("Ql_LoaiLK", "Admin");
        }
       
        public ActionResult ThemSanPham()
        {
            List<LoaiLK> a = dl.LoaiLKs.ToList();
            return View(a);
        }
        public ActionResult xlThem(FormCollection f, HttpPostedFileBase fileAnh )
        {
            LinhKien a = new  LinhKien();
            a.MaLK = "";
            a.TenLK = f["tenSP"];
            a.DonGia = int.Parse(f["donGia"].ToString());
            a.SLTon = int.Parse(f["sl"].ToString());
            a.HinhAnh = fileAnh.FileName.ToString();
            a.MoTa = f["mota"];
            a.MaLoai = f["loai"];
            var link = "/Assets/img-Sp/";
            var links = Server.MapPath(link);
            fileAnh.SaveAs(links + fileAnh.FileName);
            dl.LinhKiens.InsertOnSubmit(a);
            dl.SubmitChanges();
            return RedirectToAction("QlSanPham", "Admin");
        }
        public ActionResult XoaSanPham(string m)
        {
            LinhKien a = dl.LinhKiens.FirstOrDefault(t => t.MaLK == m);
            dl.LinhKiens.DeleteOnSubmit(a);
            dl.SubmitChanges();
            return RedirectToAction("QlSanPham", "Admin");
        }
        public ActionResult Sua(string m)
        {
            LinhKien a = dl.LinhKiens.FirstOrDefault(t => t.MaLK == m);
            return View(a);
        }
        [HttpPost]
        public ActionResult xlSua(FormCollection f, string m)
        {
            LinhKien a = new LinhKien();

            a = dl.LinhKiens.FirstOrDefault(t => t.MaLK == m);

            a.TenLK = f["tenlk"];
            a.DonGia = int.Parse(f["donGia"].ToString());
            a.SLTon = int.Parse(f["sl"].ToString());
            a.MoTa = f["mota"];
            dl.SubmitChanges();
            return RedirectToAction("QlSanPham", "Admin");


        }

        public ActionResult XoaKhachHang(string m)
        {
            KhachHang a = dl.KhachHangs.FirstOrDefault(t => t.MaKH == m);
            TAIKHOAN tk = dl.TAIKHOANs.FirstOrDefault(t => t.TENDANGNHAP == a.TENDANGNHAP);
            HoaDonDat hd = dl.HoaDonDats.FirstOrDefault(t => t.MaKH == a.MaKH);
            dl.HoaDonDats.DeleteOnSubmit(hd);
            dl.SubmitChanges();
            dl.KhachHangs.DeleteOnSubmit(a);
            dl.SubmitChanges(); 
            dl.TAIKHOANs.DeleteOnSubmit(tk);
            dl.SubmitChanges();                    
            return RedirectToAction("Ql_KhachHang", "Admin");
        }

        public ActionResult XoaHd(string m)
        {
            HoaDonDat a = dl.HoaDonDats.FirstOrDefault(t => t.MaHDDH == m);
            dl.HoaDonDats.DeleteOnSubmit(a);
            dl.SubmitChanges();
            return RedirectToAction("Ql_Hd", "Admin");
        }
        public ActionResult CheckTT(FormCollection f, string m)
        {
            HoaDonDat a = new HoaDonDat();
            a = dl.HoaDonDats.FirstOrDefault(t => t.MaHDDH == m);
            a.TinhTrangGiao = f["loai"];
            dl.SubmitChanges();

            return RedirectToAction("Ql_Hd", "Admin");
        }
        
    }
}
