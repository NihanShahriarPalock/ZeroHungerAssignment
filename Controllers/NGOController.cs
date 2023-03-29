using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHungerAssignment.Database;

namespace ZeroHungerAssignment.Controllers
{
    public class NGOController : Controller
    {
        // GET: NGO
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult OrderLists()
        {
            var db = new ZeroHungerAssignmentEntities4();
            return View(db.Employees.ToList());
        }
        public ActionResult AllOrderedList()
        {

            var db = new ZeroHungerAssignmentEntities4();
            var orderLists = db.OrderLists.ToList();
            return View(orderLists);
        }


        /*
        [HttpGet]
        public ActionResult ConfirmOrder(int id)
        {
            var db = new ZeroHungerAssignmentEntities4();
            var model = (from OrderList in db.OrderLists
                         where OrderList.Id == id
                         select OrderList).SingleOrDefault();

            return View(model);
        }

        [HttpPost]
        public ActionResult ConfirmOrder(OrderList model)
        {
            var db = new ZeroHungerAssignmentEntities4();
            var OrderList = db.OrderLists.SingleOrDefault(e => e.Id == model.Id);

            if (OrderList == null)
            {
                OrderList.Order_Status ="Collected";
               
                db.SaveChanges();
            }

            return RedirectToAction("NGO", "AllOrderedList");
        }*/

        public ActionResult Confirm(int Id)
        {
            ZeroHungerAssignmentEntities4 ctx = new ZeroHungerAssignmentEntities4();
            var order = ctx.OrderLists.Find(Id);
           
            order.Order_Status = "Collected";
            ctx.SaveChanges();
            TempData["Msg"] = "Food Will be Collected Soon";
            return RedirectToAction("AllOrderedList");

        }

        public ActionResult Cancel(int Id)
        {
            ZeroHungerAssignmentEntities4 ctx = new ZeroHungerAssignmentEntities4();
            var order = ctx.OrderLists.Find(Id);

            order.Order_Status = "Cancelled";
            ctx.SaveChanges();
            TempData["Msg"] = "Request Declined";
            return RedirectToAction("AllOrderedList");

        }


    }
}