using FutureFacePractice.Repositories;
using FutureFacePractice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FutureFacePractice.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        [Route("/")]
        [Route("Students/GetAllStudents")]
        public async Task<IActionResult> GetAllStudents()
        {
            List<Student> studentList = await _studentRepository.GetAllStudents();
            return View(studentList);
        }

        [HttpGet]
        [Route("Students/GetStudentById/{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            Student studentDetails = await _studentRepository.GetStudentById(id);
            return View(studentDetails);
        }

        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(Student student)
        {
            bool data = await _studentRepository.AddStudent(student);
            if (data) {
                return RedirectToAction("GetAllStudents");
            }
            return View(student);
        }


        [HttpGet]
        [Route("Student/EditStudent/{id}")]
        public async Task<IActionResult> EditStudent(int id)
        {
            Student student = await _studentRepository.GetStudentById(id);
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> EditStudent(Student student)
        {
            bool status = await _studentRepository.EditStudent(student);
            if (status) { 
                return RedirectToAction("GetAllStudents");
            }
            return View(student);
        }

        [HttpGet]
        [Route("Student/DeleteStudent/{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            Student student = await _studentRepository.GetStudentById(id);
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteStudent(Student student)
        {
            bool status = await _studentRepository.DeleteStudent(student);
            if (status) { return RedirectToAction("GetAllStudents"); }
            return View(student);
        }
    }
}
