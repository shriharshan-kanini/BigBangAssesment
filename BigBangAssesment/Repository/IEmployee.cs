using BigBangAssesment.Model;

namespace BigBangAssesment.Repository
{
    public interface IEmployee
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployeesById(int EmployeeId);
        Employee PostEmployee(Employee employee);
        Employee PutEmployee(int EmployeeId, Employee employee);
        Employee DeleteEmployee(int EmployeeId);
        //int GetRoomCountByRoomIdAndHotelId(int RoomId, int HotelId);
    }
}
