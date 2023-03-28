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
        public ActionResult MakeAnOrder()
        {

            return View();
        }
        [HttpPost]
        public ActionResult MakeAnOrder(OrderList model)
        {

            var db = new ZeroHungerAssignmentEntities3();
            db.OrderLists.Add(new OrderList
                { 
                Order_Status = "Waiting", 
                Order_Date=DateTime.Now

            });
            var request = db.OrderLists.SingleOrDefault();
            if (request != null)
                request.Order_Status = "Pending";

            db.SaveChanges();
            return RedirectToAction("List", "Restaurant");
        }

        public ActionResult Orders()
        {
            var db = new ZeroHungerAssignmentEntities3();
            return View(db.OrderLists.ToList());
        }
        public ActionResult List()
        {
            var db = new ZeroHungerAssignmentEntities3();
            var OrderLists = db.OrderLists.ToList();
            return View(OrderLists);
        }








    }
}