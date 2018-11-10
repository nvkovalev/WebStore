﻿using System;
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
        
        public IActionResult Index()
        {
            return View(_employeeSvc.GetAllEmployees().Select(x => GetUI(x)));
        }

        EmployeeView GetUI(Employee employee)
        {
            var ui = new EmployeeView();

            ui.FromBll(employee);

            return ui;
        }
    }
}