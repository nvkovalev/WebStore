using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebStore.BLL.Interfaces;
using WebStore.BLL.Model;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        IEmployeeService _employeeSvc;

        public HomeController(IEmployeeService employeeSvc)
        {
            _employeeSvc = employeeSvc ?? throw new ArgumentNullException(nameof(employeeSvc));
        }
         EmployeeView GetUI(Employee employee)
        {
            var ui = new EmployeeView();

            ui.FromBll(employee);

            return ui;
        }
        public IActionResult Index()
        {
            return View(_employeeSvc.GetAllEmployees().Select(x => GetUI(x)));
        }

        public IActionResult Details(int id)
        {
            var bll = _employeeSvc.GetEmployee(id);

            if (bll == null)
                return NotFound();

            var ui = new EmployeeView();
            ui.FromBll(_employeeSvc.GetEmployee(id));

            return View(ui);
        }

        public IActionResult Shop()
        {
            return View();
        }

        public IActionResult ProductDetails()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult Checkout()
        {
            return View();
        }

        public IActionResult Cart()
        {
            return View();
        }

        public IActionResult BlogSingle()
        {
            return View();
        }

        public IActionResult Blog()
        {
            return View();
        }

        public IActionResult NotFound()
        {
            return View();
        }
    }
}