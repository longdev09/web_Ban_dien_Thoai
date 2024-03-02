using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LKDienThoai_Web.Models;
namespace LKDienThoai_Web.Controllers
{
    public class HomeController : Controller
    {
        DuLieu_LkDTDataContext dl = new DuLieu_LkDTDataContext();
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult menuLLK()
        {
            List<LoaiLK> dsLLk = dl.LoaiLKs.ToList();
            return PartialView(dsLLk);
        }

    }
}
