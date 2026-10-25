using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Models;
using SchoolApp.ViewModels;
using System.Linq;

namespace SchoolApp.Controllers
{
    #region DepartmentController Class
    public class DepartmentController : Controller
    {
        private readonly SchoolDbContext _context;

        #region Constructor
        public DepartmentController(SchoolDbContext context)
        {
            _context = context;
        }
        #endregion

        #region ShowAll LifeCycle
        // GET: /Department/ShowAll
        [HttpGet]
        public IActionResult ShowAll()
        {
            var departments = _context.Departments
                                      .Include(d => d.Students)
                                      .ToList();
            return View(departments);
        }
        #endregion

        #region ShowDetails LifeCycle (Using ViewModel)
        // GET: /Department/ShowDetails?id=1
        [HttpGet]
        public IActionResult ShowDetails(int id)
        {
            var department = _context.Departments
                                     .Include(d => d.Students)
                                     .FirstOrDefault(d => d.Id == id);

            if (department == null)
            {
                return NotFound();
            }

            var viewModel = new DepartmentDetailsViewModel
            {
                DepartmentId = department.Id,
                DepartmentName = department.Name,
                ManagerName = department.MgrName,
                DepartmentState = department.Students.Count > 50 ? "Main" : "Branch",
                StudentsOver25 = department.Students
                                           .Where(s => s.Age > 25)
                                           .Select(s => new SelectListItem
                                           {
                                               Value = s.Id.ToString(),
                                               Text = $"{s.Name} ({s.Age} years)"
                                           }).ToList()
            };

            return View(viewModel);
        }
        #endregion

        #region Add LifeCycle (GET & POST)
        // GET: /Department/Add
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        // POST: /Department/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Departments.Add(department);
                _context.SaveChanges();
                return RedirectToAction(nameof(ShowAll));
            }
            return View(department);
        }
        #endregion
    }
    #endregion
}