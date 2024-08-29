using ITI.Context;
using ITI.Entities;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ITI.Repository
{
    public class CourseRepository
    {
        private readonly ITIDbContext _context;

        // Constructor
        public CourseRepository(ITIDbContext context)
        {
            _context = context;
        }

        // Create (Add) Operation
        public void AddCourse(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        // Read (Retrieve) Operations
        public IEnumerable<Course> GetAllCourses()
        {
            return _context.Courses.Include(c => c.Topic).ToList();
        }

        public Course GetCourseById(int id)
        {
            return _context.Courses.Include(c => c.Topic)
                                   .FirstOrDefault(c => c.ID == id);
        }

        // Update Operation
        public void UpdateCourse(Course course)
        {
            _context.Courses.Update(course);
            _context.SaveChanges();
        }

        // Delete Operation
        public void DeleteCourse(int id)
        {
            var course = _context.Courses.Find(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();
            }
        }
    }
}
