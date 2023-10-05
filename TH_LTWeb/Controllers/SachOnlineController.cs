using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TH_LTWeb.Models;

namespace TH_LTWeb.Controllers
{
    public class SachOnlineController : Controller
    {
        
        // GET: SachOnline
        dbSachOnlineDataContext data = new dbSachOnlineDataContext();
        private List<Sach> LaySachMoi(int count)
        {
            return data.Saches.OrderByDescending(a => a.NgayCapNhat).Take(count).ToList();
        }
        public ActionResult Index()
        {
            var listSachMoi = LaySachMoi(6);
            return View(listSachMoi);
        }
        public ActionResult ChuDePartial()
        {
            var listChuDe = from cd in data.CHUDEs select cd;
            return PartialView(listChuDe);
        }
        public ActionResult NhaXuatBanPartial()
        {
            var listNXB = from cd in data.NhaXuatBans select cd;
            return PartialView(listNXB);
        }
        public ActionResult SachTheoChuDe(int id)
        {
            var sach = from s in data.Saches where s.Id == id select s;
            return View(sach);
        }
        public ActionResult SachTheoNhaXuatBan(int id)
        {
            var sach = from s in data.Saches where s.Id == id select s;
            return View(sach);
        }
        public ActionResult ChiTietSach(int id)
        {
            var sach = from s in data.Saches 
                       where s.Id == id select s;
            return View(sach.Single());
        }
    
    }
}