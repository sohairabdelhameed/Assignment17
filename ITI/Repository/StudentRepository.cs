using ITI.Context;
using ITI.Entities;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ITI.Repository
{
    public class StudentRepository
    {
        private readonly ITIDbContext _context;

        // Constructor
        public StudentRepository(ITIDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _context.Students.Include(s => s.Department).ToList();
        }

        public Student GetStudentById(int id)
        {
            return _context.Students.Include(s => s.Department)
                                    .FirstOrDefault(s => s.ID == id);
        }

        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void UpdateStudent(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            var student = _context.Students.Find(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }
    }
}
