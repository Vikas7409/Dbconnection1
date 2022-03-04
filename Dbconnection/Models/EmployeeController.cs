using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dbconnection.Models;
namespace Dbconnection.Models
{
    public class EmployeeController : Controller
    {
        private ApplicationDbContext dbContext;

        public EmployeeController(ApplicationDbContext dbContext)

        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            List<Employee> emps =
                dbContext.Employees.ToList();
            return View(emps);

        }

        public IActionResult create()
            {
            return View();
        }

        [HttpPost]
        public IActionResult create(Employee emp)
        {
            dbContext.Employees.Add(emp);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
