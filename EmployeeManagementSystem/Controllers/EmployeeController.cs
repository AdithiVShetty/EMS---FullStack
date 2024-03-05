using BusinessLogicLayer;
using DataAccessLayer;
using System.Web.Http;

namespace EmployeeManagementSystem.Controllers
{
    [RoutePrefix("api/employee")]
    public class EmployeeController : ApiController
    {
        private readonly EmployeeService _employeeService;
        public EmployeeController()
        {
            _employeeService = new EmployeeService(new EmployeeRepository(new EMSDbContext()));
        }

        [HttpPost]
        [Route("save")]
        public IHttpActionResult SaveEmployeeProfile(EmpProfile employee)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _employeeService.SaveEmployee(employee);

            return Created(Request.RequestUri + "/" + employee.EmpCode, employee);
        }

        [HttpGet]
        [Route("getall")]
        public IHttpActionResult GetAllEmployees()
        {
            var employees = _employeeService.GetAllEmployees();
            return Ok(employees);
        }

        [HttpGet]
        [Route("get/{empCode}")]
        public IHttpActionResult GetEmployeesByCode(int empCode)
        {
            var empProfile = _employeeService.GetEmployeeByCode(empCode);
            if (empProfile == null)
                return Ok("Employee not found!"); // 404 Not Found

            return Ok(empProfile);
        }

        [HttpPut]
        [Route("update")]
        public IHttpActionResult UpdateEmpProfile(EmpProfile employee)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _employeeService.UpdateEmpProfile(employee);

            return Ok(employee);
        }

        [HttpDelete]
        [Route("delete/{empCode}")]
        public IHttpActionResult DeleteEmpProfile(int empCode)
        {
            var existingEmployee = _employeeService.GetEmployeeByCode(empCode);
            if (existingEmployee == null)
                return Ok("Employee Not found!");

            _employeeService.DeleteEmpProfile(empCode);

            return Ok("Employee profile deleted successfully!");
        }
    }
}