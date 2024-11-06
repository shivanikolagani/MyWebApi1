using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApi1.Models;
using NuGet.Packaging.Signing;

namespace MyWebApi1.Controllers
{

    public class DeptEmpResult
    {
        public int DeptId { get; set; }
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string DeptName { get; set; }

    }

    [Route("api/[controller]")]
    [ApiController]
    public class EmpDeptController : ControllerBase
    {
        private readonly MyWebApiContext _context;

        public EmpDeptController(MyWebApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<DeptEmpResult>  GetEmpDept()
        {

            var result = (from emp in _context.Employees
                         join dept in _context.Departments on emp.DeptId equals dept.DeptId
                         select new DeptEmpResult { EmpId = emp.EmpId, EmpName = emp.EmpName, DeptId = dept.DeptId, DeptName = dept.DeptName }).ToList();
            return result;
        }

    }
}
