
using PracticeTest.DAO;
using PracticeTest.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace AttendenceTracker.Controllers
{
    public class StudentApiController : ApiController
    {
        private readonly AttendanceRepository attendanceRepository = new
AttendanceRepository();


        public IEnumerable<Student> GetStudents()
        {
            return attendanceRepository.GetStudentData();
        }

        public IHttpActionResult GetStudent(int id)
        {
            var student = attendanceRepository.GetStudentById(id);
            return student != null ? (IHttpActionResult)Ok(student) : NotFound();
        }

        public IHttpActionResult PostStudent(Student student)
        {
            attendanceRepository.AddStudent(student);
            return CreatedAtRoute("DefaultApi", new { id = student.Id }, student);
        }


        public IHttpActionResult PutStudent(int id, Student student)
        {
            attendanceRepository.EditStudent(student);
            return StatusCode(HttpStatusCode.NoContent);
        }

        public IHttpActionResult DeleteStudent(int id)
        {
            attendanceRepository.DeleteStudent(id);
            return Ok();
        }
    }
}