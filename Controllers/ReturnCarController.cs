using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ReturnCarController : Controller
    {
        supercarEntities db = new supercarEntities();
        // GET: ReturnCar
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Getcar()
        {
            var car = db.carregs.ToList();
            return Json(car, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Save(returncar recar)
        {
            if (ModelState.IsValid)
            {
                db.returncars.Add(recar);
                var car = db.carregs.SingleOrDefault(e => e.carno == recar.carno);
                if (car == null)
                    return HttpNotFound("CarNo not Found"); 
                car.available = "yes";
                db.Entry(car).State = EntityState.Modified; 
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(recar);
        }

        [HttpPost]
        public ActionResult Getid(String carno)
        {
            var carn = (from s in db.rentails
                        where s.carid == carno
                        select new
                        {
                            StartDate = s.sdate,
                            EndDate = s.edate,
                            Custid = s.custid,
                            CarNo = s.carid,
                            Fee = s.fee,
                            ElapsedDays = SqlFunctions.DateDiff("day", s.edate, DateTime.Now)
                        }).ToArray();
            return Json(carn, JsonRequestBehavior.AllowGet);
        }
        }
}