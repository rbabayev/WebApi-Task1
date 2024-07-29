using ASP_Task2.Entities;
using ASP_Task2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ASP_Task2.Controllers
{
    public class EmployeeController : Controller
    {
        public static List<Employee> Employees { get; set; } = new List<Employee>
        {
            new Employee() { Id = 1, Name = "Rovsen", Description = "Babayev", Discount = 20 },
            new Employee() { Id = 2, Name = "Elvin", Description = "Teacher", Discount = 30 },
            new Employee() { Id = 3, Name = "Mehemmed", Description = "Student", Discount = 40 },
            new Employee() { Id = 4, Name = "Said", Description = "Student", Discount = 50 }
        };

        [HttpGet]
        public IActionResult Index()
        {
            var vm = new EmployeeListViewModel
            {
                Employees = Employees
            };
            return View("Employee", vm);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var vm = new EmployeeAddViewModel
            {
                Employee = new Employee()
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Add(EmployeeAddViewModel vm)
        {
            if (ModelState.IsValid)
            {
                vm.Employee.Id = (new Random()).Next(100, 1000);
                Employees.Add(vm.Employee);
                return RedirectToAction("Index");
            }
            else
            {
                return View(vm);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var item = Employees.SingleOrDefault(e => e.Id == id);
            if (item != null)
            {
                Employees.Remove(item);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var employee = Employees.SingleOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            var vm = new EmployeeUpdateViewModel
            {
                Employee = employee
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Update(EmployeeUpdateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var employee = Employees.SingleOrDefault(e => e.Id == vm.Employee.Id);
                if (employee != null)
                {
                    employee.Name = vm.Employee.Name;
                    employee.Description = vm.Employee.Description;
                    employee.Discount = vm.Employee.Discount;
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View(vm);
            }
        }
    }
}
