using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _103.Data;
using _103.Models;
using _103.IService;
using NuGet.DependencyResolver;
using static System.Runtime.InteropServices.JavaScript.JSType;
using _103.Service;
using _103.DTO;

namespace _103.Controllers
{
    public class UnitsController : Controller
    {
        private readonly IUnitService _unitService;
        private readonly ITeacherService _teacherService;
        private readonly IMarksService _marksService;
        private const int PageSize = 10; // Number of items per page

        public UnitsController(IUnitService unitService, ITeacherService teacherService)
        {
            _teacherService = teacherService;
            _unitService = unitService;
        }

        // GET: Units
        public async Task<IActionResult> Index(int pageNumber = 1)
        {
            int pageSize = 10;
            int TotalUnitCount = await _unitService.GetTotalUnit();
            int TotalPages = (int)Math.Ceiling((double)TotalUnitCount / pageSize);
            IEnumerable<UnitList> paginatedUnits = new List<UnitList>();

            if (pageNumber < 1)
            {
                pageNumber = 1;
            }
            else if (pageNumber > TotalPages)
            {
                pageNumber = TotalPages;
            }

            if (TotalUnitCount > 0)
            {
                paginatedUnits = await _unitService.FetchPaginatedUnit(pageNumber, pageSize);
            }

            // Pass the paginated data and pagination information to the view
            ViewBag.PaginatedUnits = paginatedUnits;
            ViewBag.PageNumber = pageNumber;
            ViewBag.PageSize = pageSize;

            // Calculate total pages
            ViewBag.TotalPages = TotalPages;

            return View(paginatedUnits);
        }

        // GET: Units/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var unit = await _unitService.GetUnitByIdAsync(id);
            if (unit == null)
            {
                return NotFound();
            }
            return View(unit);
        }

        // GET: Units/Create
        public async Task<IActionResult> Create()
        { 
            var teacher = await _teacherService.GetTeacherListAsync(); // Assuming a method in UnitService to get a teacher
            ViewData["TeacherID"] = new SelectList(teacher, "TeacherID", "TeacherName"); //if 2 "TeacherID" only show t.id instead of t.name
            return View();
        }

        // POST: Units/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UnitID,UnitName,Schedule,IsDeleted,TeacherID")] Unit unit) 
        {
            if (ModelState.IsValid) 
            {
                await _unitService.AddUnitAsync(unit);
                return RedirectToAction(nameof(Index));
            }
            var teacher = await _teacherService.GetTeacherListAsync(); 
            ViewData["TeacherID"] = new SelectList(teacher, "TeacherID", "TeacherName",unit.TeacherID); 
            return View(unit);
        }
      
        // GET: Units/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var unit = await _unitService.GetUnitByIdAsync(id);
            if (unit == null)
            {
                return NotFound();
            }
            var teacher = await _teacherService.GetTeacherListAsync();  //as teacher is NULL, can hold null value 
            ViewData["TeacherID"] = new SelectList(teacher, "TeacherID", "TeacherName"); 
            return View(unit);
        }

        // POST: Units/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]

         public async Task<IActionResult> Edit(int id, [Bind("UnitID,UnitName, Schedule,IsDeleted,TeacherID")] Unit unit)
         {
             if (ModelState.IsValid)
             {
                 await _unitService.UpdateUnitAsync(unit);
                 return RedirectToAction(nameof(Index));
             }
            var teacher = await _teacherService.GetTeacherListAsync();
            ViewData["TeacherID"] = new SelectList(teacher, "TeacherID", "TeacherID", unit.TeacherID);
             return View(unit);
         }

        // GET: Units/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var unit = await _unitService.GetUnitByIdAsync(id);
            if (unit == null)
            {
                return NotFound();
            }
            return View(unit);
        }

        // POST: Units/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _unitService.DeleteUnitAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
