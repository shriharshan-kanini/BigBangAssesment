using BigBangAssesment.Model;
using BigBangAssesment.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HotelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _employeeRepository;

        public EmployeeController(IEmployee employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _employeeRepository.GetEmployees();
        }

        [HttpGet("{id}")]
        public Employee GetById(int id)
        {
            return _employeeRepository.GetEmployeesById(id);
        }

        [HttpPost]
        public Employee PostEmployee(Employee employee)
        {
            return _employeeRepository.PostEmployee(employee);
        }

        [HttpPut("{id}")]
        public Employee PutEmployee(int id, Employee employee)
        {
            return _employeeRepository.PutEmployee(id, employee);
        }

        [HttpDelete("{id}")]
        public Employee DeleteEmployee(int id)
        {
            return _employeeRepository.DeleteEmployee(id);
        }
    }
}
