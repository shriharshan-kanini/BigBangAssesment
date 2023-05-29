using BigBangAssesment.Model;
using BigBangAssesment.Repository;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Repositories
{
    public class EmployeeRepository : IEmployee
    {
        private readonly HotelDbContext _context;

        public EmployeeRepository(HotelDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            try
            {
                return _context.Employees.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred: " + ex.Message);
            }
        }

        public Employee GetEmployeesById(int EmployeeId)
        {
            try
            {
                return _context.Employees.Find(EmployeeId);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred: " + ex.Message);
            }
        }

        public Employee PostEmployee(Employee employee)
        {
            try
            {
                var hotel = _context.Hotels.Find(employee.Hotel.HotelId);
                employee.Hotel = hotel;
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return employee;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred: " + ex.Message);
            }
        }

        public Employee PutEmployee(int EmployeeId, Employee employee)
        {
            try
            {
                var emp = _context.Hotels.Find(employee.Hotel.HotelId);
                employee.Hotel = emp;
                _context.Entry(employee).State = EntityState.Modified;
                _context.SaveChangesAsync();
                return employee;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred: " + ex.Message);
            }
        }

        public Employee DeleteEmployee(int EmployeeId)
        {
            try
            {
                var employee = _context.Employees.Find(EmployeeId);
                if (employee != null)
                {
                    _context.Employees.Remove(employee);
                    _context.SaveChanges();
                }
                return employee;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred: " + ex.Message);
            }
        }
    }
}
