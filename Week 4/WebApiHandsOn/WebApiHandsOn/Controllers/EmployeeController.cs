using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiHandsOn.Filters;
using WebApiHandsOn.Models;

namespace WebApiHandsOn.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class EmployeeController : ControllerBase
    {
        private readonly List<Employee> _employees;

        public EmployeeController()
        {
            _employees = GetStandardEmployeeList();
        }

        private List<Employee> GetStandardEmployeeList()
        {
            return new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Name = "Sha",
                    Salary = 85000,
                    Permanent = true,
                    Department = new Department { Id = 101, Name = "HR" },
                    Skills = new List<Skill>
                    {
                        new Skill { Id = 1, Name = "Communication" },
                        new Skill { Id = 2, Name = "Presentation" }
                    },
                    DateOfBirth = new DateTime(2005, 06, 05)
                },
                new Employee
                {
                    Id = 2,
                    Name = "Suraj",
                    Salary = 85000,
                    Permanent = true,
                    Department = new Department { Id = 102, Name = "Development" },
                    Skills = new List<Skill>
                    {
                        new Skill { Id = 1, Name = "Communication" },
                        new Skill { Id = 3, Name = "SQL" },
                        new Skill { Id = 4, Name = ".Net" },
                        new Skill { Id = 5, Name = "Data Analytics" }
                    },
                    DateOfBirth = new DateTime(2005, 06, 03)
                },
                new Employee
                {
                    Id = 3,
                    Name = "Deepika",
                    Salary = 80000,
                    Permanent = true,
                    Department = new Department { Id = 101, Name = "HR" },
                    Skills = new List<Skill>
                    {
                        new Skill { Id = 1, Name = "Communication" },
                        new Skill { Id = 6, Name = "Excel" }
                    },
                    DateOfBirth = new DateTime(2004, 09, 21)
                }
            };
        }

        [HttpGet("GetStandard")]
        [ProducesResponseType(typeof(List<Employee>), 200)]
        public ActionResult<List<Employee>> GetStandard()
        {
            return Ok(_employees);
        }

        [HttpPost("Add")]
        [ProducesResponseType(typeof(Employee), 200)]
        public ActionResult<Employee> AddEmployee([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee data is required.");
            }

            // Here we're just returning the object back for demonstration
            return Ok(employee);
        }
        [HttpPut("Update")]
        [ProducesResponseType(typeof(Employee), 200)]
        [ProducesResponseType(400)]
        public ActionResult<Employee> UpdateEmployee([FromBody] Employee updatedEmployee)
        {
            if (updatedEmployee == null || updatedEmployee.Id <= 0)
            {
                return BadRequest("Invalid employee id");
            }

            var existingEmployee = _employees.FirstOrDefault(e => e.Id == updatedEmployee.Id);

            if (existingEmployee == null)
            {
                return BadRequest("Invalid employee id");
            }

            // Update properties
            existingEmployee.Name = updatedEmployee.Name;
            existingEmployee.Salary = updatedEmployee.Salary;
            existingEmployee.Permanent = updatedEmployee.Permanent;
            existingEmployee.Department = updatedEmployee.Department;
            existingEmployee.Skills = updatedEmployee.Skills;
            existingEmployee.DateOfBirth = updatedEmployee.DateOfBirth;
            Console.WriteLine("Updated the user details successfully.");

            return Ok(existingEmployee);
        }

    }
}