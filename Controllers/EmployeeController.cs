using DatabaseProject.Interfaces;
using DatabaseProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EngineersDeskAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _EmployeeRepository;

        public EmployeeController (IEmployeeRepository employeeRepository)
        {
            _EmployeeRepository = employeeRepository;
        }

        [HttpGet]

        public ActionResult GetEmployees()
        {
            try
            {
                var employees = _EmployeeRepository.GetEmployees();
                return Ok(employees);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }
        }

        [HttpGet]

        public ActionResult GetEmployeeById(int Id)
        {
            try
            {
                var employee = _EmployeeRepository.GetEmployeeById(Id);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }
        }

        [HttpGet]

        public ActionResult GetEmployeeById_AdoNet(int Id)
        {
            try
            {
                var employee = _EmployeeRepository.GetEmployeeById_AdoNet(Id);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }
        }



        [HttpPost]
        public ActionResult AddEmployee(Employee employee )
        {
            try
            {
                var addedEmployee = _EmployeeRepository.AddEmployee(employee);
                return Ok(addedEmployee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }

        }

        [HttpGet]
        public ActionResult GetQnABank()
        {
            try
            {
                var employees = _EmployeeRepository.GetQnABank();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }
        }


        [HttpGet]
        public ActionResult GetPnrDetails(string pnrNumber)
        {
            if(pnrNumber == "4335734389")
            {
                var res = System.IO.File.ReadAllText("D:\\YouTubeDemoCode\\DatabaseProject\\Models\\PnrDetails.json");
                return Ok(res);
            }
            else
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
          
        }

    }
}
