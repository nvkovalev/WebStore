using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebStore.BLL.Interfaces;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class DetailsController : Controller
    {
        IEmployeeService _employeeSvc;

        public DetailsController(IEmployeeService employeeSvc)
        {
            _employeeSvc = employeeSvc ?? throw new ArgumentNullException(nameof(employeeSvc));
        }

        public IActionResult View(int id)
        {
            var ui = new EmployeeView();
            ui.FromBll(_employeeSvc.GetEmployee(id));

            return View(ui);
        }
    }
}