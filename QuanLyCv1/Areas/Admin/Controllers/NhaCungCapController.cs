using QuanLyCv1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyCv1.Areas.Admin.Controllers
{
    public class NhaCungCapController : Controller
    {

        // GET: Admin/NhaCungCap
        public ActionResult DanhSach(string loaiCv)
        {
            mapNhaCungCap map = new mapNhaCungCap();
            var data = map.DanhSach(loaiCv);
            ViewBag.loaiCv = loaiCv;
            return View(data);
        }

        public ActionResult ThemMoi()
        {
            return View(new NhaCungCap() { NgayDang = DateTime.Now}) ;
        }
        [HttpPost]
        public ActionResult ThemMoi(NhaCungCap model)
        {
            //check data
            if (string.IsNullOrEmpty(model.TenNhaCungCap) == true)
            {
                ModelState.AddModelError("", "Khong de trong nha cung cap");
                return View(model);

            }
            // save
            try
            {
                ShopQuanAoEntities db = new ShopQuanAoEntities();
                db.NhaCungCaps.Add(model);
                db.SaveChanges();
                return RedirectToAction("DanhSach");
            }
            catch
            {
                ModelState.AddModelError("", "Loi khong the tao");

                return View();
            }
        

        }

        public ActionResult CapNhat(int id)
        {
            var map = new mapNhaCungCap();
            var cungCap = map.ChiTiet(id);
            return View(cungCap);

        }
        [HttpPost]

        public ActionResult CapNhat(NhaCungCap model)
        {
            if (string.IsNullOrEmpty(model.TenNhaCungCap) == true)
            {
                ModelState.AddModelError("", "Khong de trong nha cung cap");
                return View(model);

            }
            // save
            try
            {
                ShopQuanAoEntities db = new ShopQuanAoEntities();
                var upDateCungCap = db.NhaCungCaps.Find(model.ID);
                upDateCungCap.TenNhaCungCap = model.TenNhaCungCap;
                upDateCungCap.TenCongViec = model.TenCongViec;
                upDateCungCap.LoaiCongViec = model.LoaiCongViec;
                upDateCungCap.NgayDang = model.NgayDang;
                upDateCungCap.LuongBatDau= model.LuongBatDau;
                db.SaveChanges();
                return RedirectToAction("DanhSach");
            }
            catch
            {
                ModelState.AddModelError("", "Loi khong the tao");

                return View();
            }
           

        }
        public ActionResult Xoa(int id)
        {
            ShopQuanAoEntities db = new ShopQuanAoEntities();
            var deleteCungCap = db.NhaCungCaps.Find(id);

            db.NhaCungCaps.Remove(deleteCungCap);
            db.SaveChanges();

            return RedirectToAction("DanhSach");

        }
        public ActionResult ChiTiet(int id)
        {
            ShopQuanAoEntities db = new ShopQuanAoEntities();

            var nhaCC = db.NhaCungCaps.Find(id);
            return View(nhaCC);
        }


       //public ActionResult ThemPhanLoai(int idLoai) {
       //    return View(new PhanLoaiCV() { ID_LOAI_CV == idLoai });
       // }
        public ActionResult CapNhatAnh(int idNhaCC)
        {
            ViewBag.idNhaCC = idNhaCC;
            return View();
        }
        [HttpPost]
        public ActionResult CapNhatAnh(int idNhaCC, HttpPostedFileBase fileAnh)
        {

            if(fileAnh == null)
            {
                ViewBag.error = "Chua chon file";
                ViewBag.idNhaCC = idNhaCC;

                return View();
            }
            if(fileAnh.ContentLength ==0)
            {
                ViewBag.error = "file khong co noi dung";
                ViewBag.idNhaCC = idNhaCC;

                return View();
            }
            var tuongDoiUrl = "/Data/images/"; // luu data 
            var tuyetDoiUrl = Server.MapPath(tuongDoiUrl); // luu file server

            fileAnh.SaveAs(tuyetDoiUrl+fileAnh.FileName);
            string fullUrl = tuyetDoiUrl+ fileAnh.FileName;
            int i = 0;
            while(System.IO.File.Exists(fullUrl)==true)
            {
                string ten = Path.GetFileNameWithoutExtension(fileAnh.FileName);
            string duoi = Path.GetExtension(fileAnh.FileName);
                fullUrl = tuyetDoiUrl+ten +"-" + i+ duoi;
                i++;
            }
            fileAnh.SaveAs(fullUrl);

            // data

            mapNhaCungCap map = new mapNhaCungCap();
            map.CapNhatAnh(idNhaCC, tuongDoiUrl + Path.GetFileName(fullUrl));

            return RedirectToAction("ChiTiet", new {id = idNhaCC});
        }
    }
}