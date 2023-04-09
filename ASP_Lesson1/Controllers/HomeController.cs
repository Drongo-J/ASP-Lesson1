using ASP_Lesson1.Entities;
using ASP_Lesson1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Lesson1.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Hello from INDEX";
        }

        public IActionResult Index2()
        {
            return View();
        }

        public ViewResult Employees()
        {
            List<Employee> list = new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Firstname = "Huseyn",
                    Lastname = "Abbasov",
                    CityId = 1
                },
                new Employee
                {
                    Id = 2,
                    Firstname = "Aykhan",
                    Lastname = "Ahmadzada",
                    CityId = 1
                },
                new Employee
                {
                    Id = 3,
                    Firstname = "Alirza",
                    Lastname = "Zaidov",
                    CityId = 2
                }
            };

            List<string> cities = new List<string>
            { "Baku", "Tokyo", "Istanbul" };
            var vm = new EmployeeViewModel()
            {
                Employees = list,
                Cities = cities
            };
            return View(list);
        }

        public IActionResult Index4()
        {
            return Ok();
        }

        public IActionResult Index5()
        {
            return NotFound();
        }

        public IActionResult Index6()
        {
            return BadRequest();
        }

        public IActionResult Index7()
        {
            return Redirect("home/index");
        }

        public IActionResult Index8()
        {
            return RedirectToAction("employees");
        }

        public IActionResult Index9()
        {
            var routeVal = new RouteValueDictionary(
                new { action = "Employees", controller = "Home" });
            return RedirectToRoute(routeVal);
        }

        public JsonResult GetJson()
        {
            List<Employee> list = new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Firstname = "Huseyn",
                    Lastname = "Abbasov",
                    CityId = 1
                },
                new Employee
                {
                    Id = 2,
                    Firstname = "Aykhan",
                    Lastname = "Ahmadzada",
                    CityId = 1
                },
                new Employee
                {
                    Id = 3,
                    Firstname = "Alirza",
                    Lastname = "Zaidov",
                    CityId = 2
                }
            };
            return Json(list);
        }

        public JsonResult INdex10(int id = -1)
        {
            List<Employee> list = new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Firstname = "Huseyn",
                    Lastname = "Abbasov",
                    CityId = 1
                },
                new Employee
                {
                    Id = 2,
                    Firstname = "Aykhan",
                    Lastname = "Ahmadzada",
                    CityId = 1
                },
                new Employee
                {
                    Id = 3,
                    Firstname = "Alirza",
                    Lastname = "Zaidov",
                    CityId = 2
                }
            };
            if (id == -1)
                return Json(list);
            else
            {
                var data = list.FirstOrDefault(e => e.Id == id);
                return Json(data);
            }
        }

        public JsonResult INdex11(string key, int id = -1)
        {
            List<Employee> list = new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Firstname = "Huseyn",
                    Lastname = "Abbasov",
                    CityId = 1
                },
                new Employee
                {
                    Id = 2,
                    Firstname = "Aykhan",
                    Lastname = "Ahmadzada",
                    CityId = 1
                },
                new Employee
                {
                    Id = 3,
                    Firstname = "Alirza",
                    Lastname = "Zaidov",
                    CityId = 2
                }
            };
            if (id == -1)
            {
                var data = list.Where(e => e.Firstname.Contains(key));
                return Json(data);
            }
            else
            {
                var data = list.Where(e => e.Id == id || e.Firstname.Contains(key));
                return Json(data);
            }
        }

        public string RouteData(int id)
        {
            return id.ToString();
        }

        public string Query(int id, string key)
        {
            return $"ID {id} key {key}";
        }
    }
}
