using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHungerAssignment.Database;

namespace ZeroHungerAssignment.Controllers
{
    public class RestaurantController : Controller
    {
        // GET: Restaurant
        public ActionResult ResIndex()
        {
            return View();
        }
        [HttpGet]
        public ActionResult OrderLists()
        {
            var db = new ZeroHungerAssignmentEntities4();
            return View(db.OrderLists.ToList());
        }
        public ActionResult List()
        {
            var db = new ZeroHungerAssignmentEntities4();
            var OrderLists = db.Employees.ToList();
            return View(OrderLists);
        }
        [HttpGet]
        public ActionResult MakeFoodRequest()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MakeFoodRequest(OrderList model)
        {
            var db = new ZeroHungerAssignmentEntities4();
            db.OrderLists.Add(model);
            db.SaveChanges();
            
            return RedirectToAction("OrderLists", "Restaurant");

        }








    }
}