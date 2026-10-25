using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Models;
using System.Linq;

namespace SchoolApp.Controllers
{
    #region StudentController Class
    public class StudentController : Controller
    {
        private readonly SchoolDbContext _context;

        #region Constructor
        public StudentController(SchoolDbContext context)
        {
            _context = context;
        }
        #endregion

        #region ShowAll Action
        public IActionResult ShowAll()
        {
            var students = _context.Students.Include(s => s.Department).ToList();
            return View(students);
        }
        #endregion

        #region ShowDetails Action
        public IActionResult ShowDetails(int id)
        {
            var student = _context.Students
                                  .Include(s => s.Department)
                                  .FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }
        #endregion
    }
    #endregion
}