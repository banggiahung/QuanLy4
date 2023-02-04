using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyCv1.Models;

namespace QuanLyCv1.Areas.Admin.Controllers
{
    public class TrangchuController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            ShopQuanAoEntities db = new ShopQuanAoEntities();

            var danhsachNCC = db.NhaCungCaps.ToList();
            return View(danhsachNCC);
        }
    }
}