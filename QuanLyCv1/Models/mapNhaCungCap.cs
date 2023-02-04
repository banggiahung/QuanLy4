using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCv1.Models
{
    public class mapNhaCungCap
    {

        public List<NhaCungCap> DanhSach()
        {
            // get danh sach
            var db = new ShopQuanAoEntities();
        
            var data = db.NhaCungCaps.ToList();
            return data;
        }
        // loc du lieu
        public List<NhaCungCap> DanhSach(string loaiCv)
        {
            // get danh sach
            var db = new ShopQuanAoEntities();

            var data = db.NhaCungCaps.Where(m=>m.LoaiCongViec.ToLower().Contains(loaiCv.ToLower()) == true || string.IsNullOrEmpty(loaiCv)).ToList();

            // sap xep
            return data.OrderBy(m=>m.TenNhaCungCap).ToList();
        }
        public NhaCungCap ChiTiet(int id)
        {
            ShopQuanAoEntities db = new ShopQuanAoEntities();
            return db.NhaCungCaps.Find(id);
        }

        public bool CapNhatAnh(int idNhaCC,string urlAnh)
        {
            try
            {
                ShopQuanAoEntities db = new ShopQuanAoEntities();
                var nhaCC = db.NhaCungCaps.Find(idNhaCC);
                nhaCC.HinhAnh = urlAnh;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
           
        }
    }
}
