
using EmployeeInfo.Data;
using EmployeeInfo.Models;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeInfo.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDbContext context;

        public EmployeeController(EmployeeDbContext context)
        {
            this.context = context;

        }

        public IActionResult Index()
        {
            var result = context.tEmployee.ToList();
            return View(result);
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddEmployee(Employee model)
        {
            if (ModelState.IsValid)
            {
                var pro = new Employee()
                {
                    Name = model.Name,
                    City = model.City,
                    State = model.State,
                    Salary=model.Salary
                };
                context.tEmployee.Add(pro);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Empty Field cannot be submit";
                return View(model);
            }

        }
        public IActionResult DeleteEmployee(int id)
        {
            var pro = context.tEmployee.SingleOrDefault(p => p.Id == id);
            context.tEmployee.Remove(pro);
            context.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult UpdateEmployee(int id)
        {
            var pro = context.tEmployee.SingleOrDefault(p => p.Id == id);
            var result = new Employee()
            {
                Id = pro.Id,
                Name = pro.Name,
                City=pro.City,
                State = pro.State,
                Salary = pro.Salary
            };
            return View(result);
        }

        [HttpPost]
        public IActionResult UpdateEmployee(Employee model)
        {
            var pro = new Employee()
            {
                Id = model.Id,
                Name = model.Name,
                City = model.City,
                State = model.State,
                Salary=model.Salary
            };
            context.tEmployee.Update(pro);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}

   