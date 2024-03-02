using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LKDienThoai_Web.Models;
namespace LKDienThoai_Web.Controllers
{
    public class HienThiSanPhamController : Controller
    {
        //
        // GET: /HienThiSanPham/
        DuLieu_LkDTDataContext dl = new DuLieu_LkDTDataContext();
        public ActionResult FlaseSale()
        {
            List<LinhKien> FlaseSale = dl.LinhKiens.Where(t=> t.MaLoai=="LLK6") .Take(7).ToList();
            return PartialView(FlaseSale);
        }
        
        public ActionResult HienThiSanPhamIphone_Home()
        {
            List<LinhKien> dsLk = dl.LinhKiens.Where(t => t.MaLoai == "LLK1").Take(5).ToList();
            return PartialView(dsLk);
        }
        public ActionResult HienThiSanPhamCapSac_Home()
        {
            List<LinhKien> dsLk = dl.LinhKiens.Where(t => t.MaLoai == "LLK2").Take(6).ToList();
            return PartialView(dsLk);
        }
        public ActionResult HienThiSanPhamDuPhong_Home()
        {
            List<LinhKien> dsLk = dl.LinhKiens.Where(t => t.MaLoai == "LLK5").Take(8).ToList();
            return PartialView(dsLk);
        }
        public ActionResult HienThiSanPhamTaiNghe_Home()
        {
            List<LinhKien> dsLk = dl.LinhKiens.Where(t => t.MaLoai == "LLK3").Take(4).ToList();
            return PartialView(dsLk);
        }



        public ActionResult HienThiSanPhamTheoLoai(string maloai)
        {
            List<LinhKien> dsLK = dl.LinhKiens.Where(t => t.MaLoai == maloai).ToList();
            LoaiLK name = dl.LoaiLKs.FirstOrDefault(t => t.MaLoai == maloai);
            ViewBag.TenLoai = name.TenLoai;
            return View(dsLK);
        }



        public ActionResult XemChiTietSp(string mlk)
        {
            LinhKien a = dl.LinhKiens.FirstOrDefault(t => t.MaLK == mlk);
            return View(a);
        }
    }
}
