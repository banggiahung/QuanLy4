using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyCv1.Models;


namespace QuanLyCv1.Areas.Admin.Controllers
{
    public class LoaiCongViecController : Controller
    {
        // GET: Admin/LoaiCongViec
        public ActionResult DanhSach(string loaiCv)
        {
            mapLoaiCongViec map = new mapLoaiCongViec();
            var data = map.DanhSach(loaiCv);
            ViewBag.loaiCv = loaiCv;
            return View(data);
        }
    }
}