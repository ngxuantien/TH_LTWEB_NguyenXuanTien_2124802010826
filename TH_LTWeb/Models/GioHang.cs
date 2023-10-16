using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TH_LTWeb.Models
{
    public class GioHang
    {
        dbSachOnlineDataContext db = new dbSachOnlineDataContext();
        public int iMaSach { get; set; }
        public string sTenSach { get; set; }
        public string sAnhBia { get; set; }
        public double dDonGia { get; set; }
        public int iSoLuong { get; set; }
        public double dThanhTien { 
            get { return iSoLuong * dDonGia; }
        }
        public GioHang(int ms)
        {
            iMaSach = ms;
            Sach s = db.Saches.Single(n => n.Id == iMaSach);
            sTenSach = s.Name;
            sAnhBia = s.AnhBia;
            dDonGia = double.Parse(s.Price.ToString());
            iSoLuong = 1;
        }
    }
}