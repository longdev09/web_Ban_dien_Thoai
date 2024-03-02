using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LKDienThoai_Web.Models;
namespace LKDienThoai_Web.Controllers
{
    public class GioHangController : Controller
    {
        DuLieu_LkDTDataContext dl = new DuLieu_LkDTDataContext();
        //
        // GET: /GioHang/

        // tao gio hang
        public GioHang taoGio()
        {
            GioHang cart = (GioHang)Session["CART"];
            return cart;
        }
        // Lưu giỏ hàng
       
        public void LuuGioHang(GioHang cart)
        {
            Session["CART"] = cart; 
            
        }
        public ActionResult ChonMua(string mlk)
        {
            GioHang cart = taoGio();
            if (cart == null)
            {
                cart = new GioHang();
                cart.ThemGio(mlk);
            }
            else
            {
                ILinhKien s = cart.dsLk.FirstOrDefault(t => t.maLK == mlk);
                if (s == null)
                {
                    cart.ThemGio(mlk);
                }
                else
                {
                    s.slMua++;
                }
            }
            LuuGioHang(cart);
            return RedirectToAction("Index", "Home");
        }



        public ActionResult XemChiTietGioHang()
        {
            if(Session["CART"] == null)
            {
                return RedirectToAction("GioHangNull", "GioHang");
            }
            else
            {
                GioHang cart = taoGio();
                ViewBag.tongSlhang =  cart.DemSL();
                ViewBag.tongTien = cart.TongTien();
                List<ILinhKien> dsCart = cart.dsLk;
                return View(dsCart);

            }
        }

        public ActionResult GioHangNull()
        {
            return View();
        }

        public ActionResult xoaSpTrongGio(string malk)
        {
            GioHang cart = taoGio();
            cart.Xoa(malk);
            return RedirectToAction("XemChiTietGioHang", "GioHang");
        }
        [HttpPost]
        public ActionResult LuuThem(string m, FormCollection f)
        {
            GioHang cart = taoGio();
            cart.CapNhatSl(m, int.Parse(f["sl"]));
            return RedirectToAction("XemChiTietGioHang", "GioHang");
        }

        
    }
}
