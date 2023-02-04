using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCv1.Models
{
    public class mapLoaiCongViec
    {

        public List<Loai_C_V> DanhSach()
        {
            // get danh sach
            var db = new ShopQuanAoEntities();
        
            var data = db.Loai_C_V.ToList();
            return data;
        }
        // loc du lieu
        public List<Loai_C_V> DanhSach(string loaiCv)
        {
            // get danh sach
            var db = new ShopQuanAoEntities();

            var data = db.Loai_C_V.Where(m=>m.LoaiCV.ToLower().Contains(loaiCv.ToLower()) == true || string.IsNullOrEmpty(loaiCv)).ToList();

            // sap xep
            return data.OrderBy(m=>m.LoaiCV).ToList();
        }
       
    }
}
