using Microsoft.AspNetCore.Mvc;
using Student_CRUD.DataAccess;
using Student_CRUD.Models;

namespace Student_CRUD.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRespository _studentRespository;

        public StudentController(IStudentRespository studentRespository)
        {
            _studentRespository = studentRespository;
        }

        // GET: Student
        public IActionResult Index()
        {
            var students = _studentRespository.GetAllStudents();
            return View(students);
        }

        // GET: Student/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var student = await _studentRespository.GetStudentByIdAsync(id);
            if (student == null) return NotFound();
            return View(student);
        }

        // GET: Student/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Students student)
        {
            if (ModelState.IsValid)
            {
                await _studentRespository.CreateStudentAsync(student);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Student/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var student = await _studentRespository.GetStudentByIdAsync(id);
            if (student == null) return NotFound();
            return View(student);
        }

        // POST: Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Students student)
        {
            if (id != student.StudentID) return NotFound();

            if (ModelState.IsValid)
            {
                var updated = await _studentRespository.UpdateStudentAsync(student);
                if (!updated) return NotFound();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _studentRespository.GetStudentByIdAsync(id);
            if (student == null) return NotFound();
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deleted = await _studentRespository.DeleteStudentAsync(id);
            if (!deleted) return NotFound();
            return RedirectToAction(nameof(Index));
        }
    }
}
