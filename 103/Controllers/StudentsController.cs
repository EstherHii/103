using Microsoft.AspNetCore.Mvc;
using _103.Data;
using _103.Models;
using _103.IService;
using _103.Service;
using _103.DTO;
using System.Drawing.Printing;

namespace _103.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IUnitService _unitService;

        public StudentsController(IStudentService studentService, IUnitService unitService)
        {
            _studentService = studentService;
            _unitService = unitService;
        }

        // GET: Students
        public async Task<IActionResult> Index(int pageNumber = 1)
        {
            int pageSize = 10;
            int TotalStudentCount = await _studentService.GetTotalStudent();
            int TotalPages = (int)Math.Ceiling((double)TotalStudentCount / pageSize);
            IEnumerable<Student> paginatedStudents = new List<Student>();
           
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }
            else if (pageNumber > TotalPages)
            {
                pageNumber = TotalPages;
            }

            if (TotalStudentCount > 0)
            {
                paginatedStudents = await _studentService.FetchPaginatedStudent(pageNumber, pageSize);              
            }

            // Pass the paginated data and pagination information to the view
            ViewBag.PaginatedStudents = paginatedStudents;
            ViewBag.PageNumber = pageNumber;
            ViewBag.PageSize = pageSize;

            // Calculate total pages
            ViewBag.TotalPages = TotalPages;

            return View(paginatedStudents);
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var StudentList = await _studentService.GetStudentResultByID(id);
            if (StudentList == null)
            {
                return NotFound();
            }
            return View(StudentList);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentID,StudentName,StudentEmail,IsDeleted")] Student student)
        {
            int DuplicateEmailCheck = await _studentService.DuplicateEmailCheck(student);
            if (DuplicateEmailCheck > 1) 
            {
                ModelState.AddModelError("student",
                    "This email is already registered. Please use a different email.");
            }

            if (ModelState.IsValid)
            {
                await _studentService.AddStudentAsync(student);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentID,StudentName,StudentEmail,IsDeleted")] Student student)
        {

            if (ModelState.IsValid)
            {
                await _studentService.UpdateStudentAsync(student);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _studentService.DeleteStudentAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }  
}
