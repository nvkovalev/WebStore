using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.BLL.Interfaces;
using WebStore.BLL.Model;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class EmployeesController : Controller
    {
        IEmployeeService _employeeSvc;

        public EmployeesController(IEmployeeService employeeSvc )
        {
            _employeeSvc = employeeSvc ?? throw new ArgumentNullException(nameof(employeeSvc));
        }

        EmployeeView GetUI(Employee employee)
        {
            var ui = new EmployeeView();

            ui.FromBll(employee);

            return ui;
        }

        Employee GetBll(EmployeeView ui)
        {
            return ui.FromUI();
        }


        public IActionResult Index()
        {
            return View(_employeeSvc.GetAll().Select(x => GetUI(x)));
        }

        public IActionResult Details(int id)
        {
            var bll = _employeeSvc.GetById(id);

            if (bll == null)
                return NotFound();

            var ui = new EmployeeView();
            ui.FromBll(_employeeSvc.GetById(id));

            return View(ui);
        }

        public IActionResult Edit(int? id)
        {
            var ui = new EmployeeView();

            if (id.HasValue)
            {
                var bll = _employeeSvc.GetById(id.Value);

                if (bll == null)
                    return NotFound();

                ui = new EmployeeView();
                ui.FromBll(_employeeSvc.GetById(id.Value));
            }
            
            return View(ui);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeView ui)
        {
            if (ui.Id > 0)
            {
                var bll = _employeeSvc.GetById(ui.Id);

                if (bll == null)
                    return NotFound();

                bll.Age = ui.Age;
                bll.BirthDate = ui.BirthDate;
                bll.FirstName = ui.FirstName;
                bll.Patronymic = ui.Patronymic;
                bll.Position = ui.Position;
                bll.SurName = ui.SurName;                
            }
            else
            {                                
                var bll = GetBll(ui);
                _employeeSvc.AddNew(bll);
            }

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(int id)
        {
            var bll = _employeeSvc.GetById(id);

            if (bll == null)
                return NotFound();

            _employeeSvc.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}