using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHungerAssignment.Database;

namespace ZeroHungerAssignment.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Employees()
        {
            var db = new ZeroHungerAssignmentEntities4();
            return View(db.Employees.ToList());
        }
        public ActionResult List()
        {
            var db = new ZeroHungerAssignmentEntities4();
            var Employees = db.Employees.ToList();
            return View(Employees);
        }
        [HttpGet]
        public ActionResult AddEmployees()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployees(Employee model)
        {
            var db = new ZeroHungerAssignmentEntities4();
            db.Employees.Add(model);
            db.SaveChanges();
            TempData["Msg"] = "Employee Added Successfully";
            return RedirectToAction("List", "Employee");

        }

        public ActionResult EditEmployee(int Id)
        {
            var db = new ZeroHungerAssignmentEntities4();
            var emp = (from e in db.Employees
                      where e.Id == Id
                      select e).SingleOrDefault();
            return View(emp);
        }
        [HttpPost]
        public ActionResult EditEmployee(Employee upemp)
        {
            var db = new ZeroHungerAssignmentEntities4();
            var exst = (from e in db.Employees
                        where e.Id == upemp.Id
                        select e).SingleOrDefault();
            exst.Name = upemp.Name;
            exst.Email = upemp.Email;
            exst.Age = upemp.Age;
            exst.Gender = upemp.Gender;

            //db.Entry(exst).CurrentValues.SetValues(upstudent);
            db.SaveChanges();


            //db.Students.Remove(exst);
            TempData["Msg"] = "Information Updated Successfully";
            return RedirectToAction("List", "Employee");
        }

        public ActionResult DeleteEmployee(int id)
        {
            var employee = new Employee() { Id = id };

            using (var context = new ZeroHungerAssignmentEntities4())
            {
                context.Employees.Attach(employee);
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
            TempData["Msg"] = "Employee Removed Successfully";
            return RedirectToAction("List", "Employee");
        }

       

    }
}