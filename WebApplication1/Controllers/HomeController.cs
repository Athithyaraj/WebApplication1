using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using WebApplication1.data;
using WebApplication1.Models;
using System.Linq;
namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            EmployeeModel employeeModel = new EmployeeModel();
            employeeModel.EmployeeList = new List<SelectListItem>();
            employeeModel.EmployeeList.Add(new SelectListItem
            {
                Value = "",
                Text = "Select Employee"
            });

            TestDBContext testDBContext = new TestDBContext();
            var data = testDBContext.Employees;
            foreach (var item in data)
            {
                employeeModel.EmployeeList.Add(new SelectListItem
                {
                    Value = Convert.ToString(item.Id),
                    Text = item.EmployeeName
                });
            }
            return View(employeeModel);
        }
        [HttpPost]
        public IActionResult Index(EmployeeModel employeeModel)
        {
            employeeModel.EmployeeList = new List<SelectListItem>();
            employeeModel.EmployeeList.Add(new SelectListItem
            {
                Value = "",
                Text = "Select Employee"
            });

            TestDBContext testDBContext = new TestDBContext();
            var data = testDBContext.Employees;
            foreach (var item in data)
            {
                employeeModel.EmployeeList.Add(new SelectListItem
                {
                    Value = Convert.ToString(item.Id),
                    Text = item.EmployeeName
                });
            }
            ViewBag.SelectedValue = employeeModel.EmployeeId;
            ViewBag.SelectedText = data.Where(m => m.Id == employeeModel.EmployeeId).FirstOrDefault().EmployeeName;
            return View(employeeModel);
        }
    }
}
