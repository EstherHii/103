using System;
using Microsoft.AspNetCore.Mvc;
using _103.Data;
using _103.Models;
using _103.IService;
using _103.Service;

namespace _103.Controllers
{
    public class TeachersController : Controller
    {
        private readonly ITeacherService _teacherService;
      
        public TeachersController(ITeacherService TeacherService)
        {
            _teacherService = TeacherService;
        }

        // GET: Teachers
        public async Task<IActionResult> Index(int pageNumber = 1)
        {
            int pageSize = 10;
            int TotalTeacherCount = await _teacherService.GetTotalTeacher();
            int TotalPages = (int)Math.Ceiling((double)TotalTeacherCount / pageSize);
            IEnumerable<Teacher> paginatedTeachers = new List<Teacher>();

            if (pageNumber < 1)
            {
                pageNumber = 1;
            }
            else if (pageNumber > TotalPages)
            {
                pageNumber = TotalPages;
            }

            if (TotalTeacherCount > 0)
            {
                paginatedTeachers = await _teacherService.FetchPaginatedTeacher(pageNumber, pageSize);
            }

            // Pass the paginated data and pagination information to the view
            ViewBag.PaginatedTeachers = paginatedTeachers;
            ViewBag.PageNumber = pageNumber;
            ViewBag.PageSize = pageSize;

            // Calculate total pages
            ViewBag.TotalPages = TotalPages;

            return View(paginatedTeachers);
        }

        // GET: Teachers/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var teacher = await _teacherService.GetTeacherByIdAsync(id); 
            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }

        // GET: Teachers/Create
        // Load empty create page
        public IActionResult Create()
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            return View();
        }

        // POST: Teachers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeacherID,TeacherName,IsDeleted")] Teacher teacher) 
        {
            if (ModelState.IsValid)
            {
                await _teacherService.AddTeacherAsync(teacher);
                return RedirectToAction(nameof(Index));
            }
            return View(teacher);
        }

        // GET: Teachers/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var teacher = await _teacherService.GetTeacherByIdAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }

        // POST: Teachers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TeacherID,TeacherName,IsDeleted")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
               await _teacherService.UpdateTeacherAsync(teacher);
               return RedirectToAction(nameof(Index));
            }
            return View(teacher);
        }

        // GET: Teachers/Delete/5
        // Loading the view i wan to delete 
        public async Task<IActionResult> Delete(int id) 
        {
            var teacher = await _teacherService.GetTeacherByIdAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }

        // POST: Teachers/Delete/5
        // Confirm the deletion
        [HttpPost, ActionName("Delete")] 
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _teacherService.DeleteTeacherAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
