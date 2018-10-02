using System.Collections.Generic;
using WebApplication1;

namespace EmployeeManagementSystem.Services
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployees();

        Employee GetEmployee(int id);

        void AddEmployee(Employee employee);

        void UpdateEmployee(Employee employee);

        bool DeleteEmployee(int id);
    }
}
