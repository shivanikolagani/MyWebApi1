using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApi1.Models;
using System.Composition;

namespace MyWebApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JoinsController : ControllerBase
    {
        private readonly MyWebApiContext _context;
        public JoinsController(MyWebApiContext context)
        {
            _context = context;
        }

        [HttpGet("GetEmployeeDetails")]
        public object GetJoinDetails()
        {
            var query = from employee in _context.Employees
                        join department in _context.Departments on employee.DeptId equals department.DeptId
                        join library in _context.Libraries on employee.LibraryId equals library.LibraryId
                        select new
                        {
                            EmployeeName = employee.EmpName,
                            DepartmentName = department.DeptName,
                            LibraryNam = library.LibraryName
                        };
            return query;

        }


    }
}
