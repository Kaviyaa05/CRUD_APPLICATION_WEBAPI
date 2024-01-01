using PracticeTest.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PracticeTest.DAO
{
    public class AttendanceRepository
    {
        private masterEntities db = new masterEntities();

        public IEnumerable<Student> GetStudentData()
        {
            return db.Students.ToList();
        }

        public Student GetStudentById(int id)
        {
            return db.Students.Find(id);
        }

        public void AddStudent(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
        }

        public void EditStudent(Student student)
        {
            if (student != null)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteStudent(int id)
        {
            var student = db.Students.Find(id);
            if (student != null)
            {
                db.Students.Remove(student);
                db.SaveChanges();
            }
        }
    }
}