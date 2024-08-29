using ITI.Context;
using ITI.Entities;
using ITI.Repository;

class Program
{
    static void Main(string[] args)
    {
        using (var context = new ITIDbContext())
        {
            var departmentRepo = new DepartmentRepository(context);
            var courseRepo = new CourseRepository(context);

            // Add a new Department
            var newDepartment = new Department { Name = "Computer Science", HiringDate = DateTime.Now };
            departmentRepo.AddDepartment(newDepartment);

            // Add a new Course
            var newCourse = new Course { Name = "Algorithms", Duration = 10 };
            courseRepo.AddCourse(newCourse);

            // Get and display all Departments
            var departments = departmentRepo.GetAllDepartments();
            foreach (var department in departments)
            {
                Console.WriteLine($"Department: {department.Name}");
            }

            // Get and display all Courses
            var courses = courseRepo.GetAllCourses();
            foreach (var course in courses)
            {
                Console.WriteLine($"Course: {course.Name}, Duration: {course.Duration} weeks");
            }
        }
    }
}
