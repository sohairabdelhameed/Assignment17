using ITI.Context;
using ITI.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ITI.Repository
{
    public class DepartmentRepository
    {
        private readonly ITIDbContext _context;

        // Constructor
        public DepartmentRepository(ITIDbContext context)
        {
            _context = context;
        }

        // Create (Add) Operation
        public void AddDepartment(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
        }

        // Read (Retrieve) Operations
        public IEnumerable<Department> GetAllDepartments()
        {
            return _context.Departments.ToList();
        }

        public Department GetDepartmentById(int id)
        {
            return _context.Departments.FirstOrDefault(d => d.ID == id);
        }

        // Update Operation
        public void UpdateDepartment(Department department)
        {
            _context.Departments.Update(department);
            _context.SaveChanges();
        }

        // Delete Operation
        public void DeleteDepartment(int id)
        {
            var department = _context.Departments.Find(id);
            if (department != null)
            {
                _context.Departments.Remove(department);
                _context.SaveChanges();
            }
        }
    }
}
