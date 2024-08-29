using ITI.Context;
using ITI.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ITI.Repository
{
    public class InstructorRepository
    {
        private readonly ITIDbContext _context;

        // Constructor
        public InstructorRepository(ITIDbContext context)
        {
            _context = context;
        }

        // Create (Add) Operation
        public void AddInstructor(Instructor instructor)
        {
            _context.Instructors.Add(instructor);
            _context.SaveChanges();
        }

        // Read (Retrieve) Operations
        public IEnumerable<Instructor> GetAllInstructors()
        {
            return _context.Instructors.ToList();
        }

        public Instructor GetInstructorById(int id)
        {
            return _context.Instructors.FirstOrDefault(i => i.ID == id);
        }

        // Update Operation
        public void UpdateInstructor(Instructor instructor)
        {
            _context.Instructors.Update(instructor);
            _context.SaveChanges();
        }

        // Delete Operation
        public void DeleteInstructor(int id)
        {
            var instructor = _context.Instructors.Find(id);
            if (instructor != null)
            {
                _context.Instructors.Remove(instructor);
                _context.SaveChanges();
            }
        }
    }
}
