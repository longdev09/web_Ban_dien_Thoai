using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LKDienThoai_Web.Models;
namespace LKDienThoai_Web.Controllers
{
    public class ThemSanPhamController : Controller
    {
        //
        // GET: /ThemSanPham/
        DuLieu_LkDTDataContext dl = new DuLieu_LkDTDataContext();

        //public ActionResult ThemMoi()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult xlThemMoi(SPLINHKIEN t, HttpPostedFileBase fup)
        //{
        //    dl.SPLINHKIENs.InsertOnSubmit(t);
        //    dl.SubmitChanges();
        //    string Tenfile = Server.MapPath("/HinhAnhSP" + fup.FileName);
        //    fup.SaveAs(Tenfile);
        //    return RedirectToAction("DsSach");
        //}
    }
}
