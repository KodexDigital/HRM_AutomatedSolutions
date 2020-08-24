using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Standard.Utility.Api;
using System.Standard.Utility.Globals;
using System.Text;
using System.Threading.Tasks;
using HRM_Automated.DTO.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace HRM_Automated.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly HttpClient client;
        private string responseResult = null;
        private IEnumerable<EmployeeDTO> employeesList;
        private EmployeeDTO recievecedEmployeeDto;

        public EmployeeController(HttpClient client)
        {
            this.client = client;
        }

        /// <summary>
        /// Dispalying all employee from the endpoint 
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            using var client = HttpConnect.client;
            using var response = await client.GetAsync(EndpointConnect.BaseAddress + EndpointConnect.GetAllEmployee);
            responseResult = await response.Content.ReadAsStringAsync();
            employeesList = JsonConvert.DeserializeObject<IEnumerable<EmployeeDTO>>(responseResult);
            return View(employeesList);
        }


        public ViewResult GetEmployee() => View();

        [HttpPost]
        public async Task<IActionResult> GetEmployee(Guid id)
        {
            using var response = await client.GetAsync(EndpointConnect.BaseAddress + EndpointConnect.GetEmployeeById + id);
            responseResult = await response.Content.ReadAsStringAsync();
            employeesList = JsonConvert.DeserializeObject<IEnumerable<EmployeeDTO>>(responseResult);
            return View(employeesList);
        }


        public ViewResult CreateEmployee() => View();

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(EmployeeDTO model)
        {
            recievecedEmployeeDto = new EmployeeDTO();
            string url = EndpointConnect.BaseAddress + EndpointConnect.CreateNewEmployee;
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), EndpointHeader.UTF8Encoding, EndpointHeader.DefaultMediaType);
            using var response = await client.PostAsync(url, content);
            responseResult = await response.Content.ReadAsStringAsync();
            recievecedEmployeeDto = JsonConvert.DeserializeObject<EmployeeDTO>(responseResult);
            return View(recievecedEmployeeDto);
        }

    }
}