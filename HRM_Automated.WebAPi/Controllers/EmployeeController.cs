using System;
using System.Collections.Generic;
using System.Linq;
using System.Standard.DAL.Admin.IRepos;
using System.Standard.DAL.APIRepos;
using System.Standard.Models.DataModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRM_Automated.WebAPi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize] //securing with jwt: protected by jtw bearer
    public class EmployeeController : ControllerBase
    {
        private readonly IWrapper wrapper;
        private readonly EmployeeRepo employeeRepo;

        public EmployeeController(IWrapper wrapper, EmployeeRepo employee)
        {
            this.wrapper = wrapper;
            employeeRepo = employee;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        [Route("get-all-employee")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployee()
        {
            try
            {
                return Ok(await employeeRepo.GetEmployees());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        [Route("get-employee-by-id")]
        public async Task<ActionResult<Employee>> GetEmployeeById(Guid id)
        {
            try
            {
                var result = await employeeRepo.GetEmployeeById(id);
                if (result != null)
                    return Ok(result);
                return NotFound(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error retrieving data for id {id} from the database");
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        [Route("get-employee-by-name")]
        public async Task<ActionResult<Employee>> GetEmployeeByName(string name)
        {
            try
            {
                var restult = await employeeRepo.GetEmployeeByName(name);
                if (restult != null)
                    return Ok(restult);
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }


        [HttpGet]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        [Route("get-employee-by-phone-number")]
        public async Task<ActionResult<Employee>> GetEmployeeByPhone(string phoneNumber)
        {
            try
            {
                var restult = await employeeRepo.GetEmployeeByPhone(phoneNumber);
                if (restult != null)
                    return Ok(restult);
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        [Route("get-employee-by-email")]
        public async Task<ActionResult<Employee>> GetEmployeeByEmail(string email)
        {
            try
            {
                var restult = await employeeRepo.GetEmployeeByEmail(email);
                if (restult != null)
                    return Ok(restult);
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        [Route("create-new-employee")]
        //[Authorize]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            try
            {
                if (employee == null)
                    return BadRequest();
                wrapper.Employee.Add(employee);
                await wrapper.SaveChangesAsync();

                return CreatedAtAction(nameof(GetAllEmployee), new { id = employee.Id }, employee);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                  "Error creating new employee record");
            }
        }
    }
}