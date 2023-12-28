using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using _103.Data;
using _103.Models;
using _103.IService;
using _103.DTO;

namespace _103.Controllers
{
    public class MarksController : Controller
    {
        private readonly IMarksService _marksService;
        private readonly IStudentService _studentService;
        private readonly IUnitService _unitService;

        public MarksController(IMarksService marksService, IStudentService studentService, IUnitService unitService)
        {
            _marksService = marksService;
            _studentService = studentService;
            _unitService = unitService;
        }

        // GET: Marks
        public async Task<IActionResult> Index(int pageNumber = 1)
        {
            int pageSize = 10;
            int TotalUnitCount = await _marksService.GetTotalMark();
            int TotalPages = (int)Math.Ceiling((double)TotalUnitCount / pageSize);
            IEnumerable<MarkList> paginatedMark = new List<MarkList>();

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
                paginatedMark = await _marksService.FetchPaginatedMark(pageNumber, pageSize);
            }

            // Pass the paginated data and pagination information to the view
            ViewBag.PaginatedMark = paginatedMark;
            ViewBag.PageNumber = pageNumber;
            ViewBag.PageSize = pageSize;

            // Calculate total pages
            ViewBag.TotalPages = TotalPages;

            return View(paginatedMark);   
        }

        // GET: Marks/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var MarkList = await _marksService.GetMarksByIdAsync(id);
            if (MarkList == null)
            {
                return NotFound();
            }
            return View(MarkList);
        }

        // GET: Marks/Create
        public async Task<IActionResult> Create(int? id = null)
        {
            var student = await _studentService.GetStudentListAsync();
            int studentId = id.HasValue? id.Value :student.FirstOrDefault().StudentID;

            var unit = await _marksService.GetStudentUnitAvailable(studentId);
            ViewData["StudentID"] = new SelectList(student, "StudentID", "StudentName", studentId);
            ViewData["UnitID"] = new SelectList(unit, "UnitID", "UnitName"); //dropdown
            return View();
        }

        // POST: Marks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MarkID,Mark,Grade,IsDeleted,StudentID,UnitID")] Marks marks)
        {
            int UnitCount = await _marksService.EligibleCheckResult(marks);
            if (UnitCount >= 10 && marks.Mark < 50)
            {
                ModelState.AddModelError("marks",
                    "Student have already reached the maximum limit of 10 units.");
            }

            var SameUnitCount = await _marksService.EligibleCheckDuplicate(marks);
            if (SameUnitCount > 0)
            {
                ModelState.AddModelError("marks",
                    "Student has already taken this unit. Duplicate entries are not allowed.");
            }

            if (ModelState.IsValid)
            {           
                marks.GenerateGrade();
                await _marksService.AddMarksAsync(marks);
                return RedirectToAction(nameof(Index));
            }
            var student = await _studentService.GetStudentListAsync();
            var unit = await _marksService.GetStudentUnitAvailable(marks.StudentID);
            ViewData["StudentID"] = new SelectList(student, "StudentID", "StudentName", marks.StudentID);
            ViewData["UnitID"] = new SelectList(unit, "UnitID", "UnitName", marks.UnitID);
            MarkList maskList= new(marks);
            return View(maskList);
        }

        // GET: Marks/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var marks = await _marksService.GetMarksByIdAsync(id);
            if (marks == null)
            {
                return NotFound();
            }
            var student = await _studentService.GetStudentListAsync();
            var unit = await _unitService.GetUnitListAsync();
           
            return View(marks);
        }

        // POST: Marks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MarkID,Mark,Grade,isDeleted,UnitID,StudentID")] Marks marks)
        {
            int UnitCount = await _marksService.EligibleCheckResultEdit(marks);
            if (UnitCount >= 10 && marks.Mark < 50) //wont affect changing from pass to pass 
            {
                ModelState.AddModelError("marks",
                    "Student have already reached the maximum limit of 10 units.");
            }

            marks.GenerateGrade();
            var grade = marks.Grade;
            if (ModelState.IsValid)
            {
                await _marksService.UpdateMarksAsync(marks);
                return RedirectToAction(nameof(Index));
            }
           
            var markList = await _marksService.GetMarksByIdAsync(id);
            markList.Mark = marks.Mark;
            return View(markList);
        }

        // GET: Marks/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marks = await _marksService.GetMarksByIdAsync(id);
            if (marks == null)
            {
                return NotFound();
            }
            return View(marks);
        }

        // POST: Marks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _marksService.DeleteMarksAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
