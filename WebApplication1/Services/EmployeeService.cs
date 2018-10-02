using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using WebApplication1;

namespace EmployeeManagementSystem.Services
{
    public class EmployeeService : IEmployeeService
    {
        private EmployeeManagementEntities employeeManagementEntities = null;

        public EmployeeService()
        {
            employeeManagementEntities = new EmployeeManagementEntities();
        }

        public void AddEmployee(Employee employee)
        {
            try
            {
                if (isValidEmployee(employee))
                {
                    employeeManagementEntities.Employees.Add(employee);
                    employeeManagementEntities.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteEmployee(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("Invalid id", "id");
            }

            Employee employ = employeeManagementEntities.Employees.FirstOrDefault(emp => emp.ID == id);
            employeeManagementEntities.Entry(employ).State = EntityState.Deleted;
            employeeManagementEntities.SaveChanges();
            return true;
        }

        public Employee GetEmployee(int id)
        {
            if(id < 1)
            {
                throw new ArgumentException("Invalid id", "id");
            }
            
            return employeeManagementEntities.Employees.ToList().SingleOrDefault(emp => emp.ID == id);
        }

        public List<Employee> GetEmployees()
        {
            return employeeManagementEntities.Employees.ToList();
        }

        public void UpdateEmployee(Employee employee)
        {
            if(isValidEmployee(employee))
            {
                Employee employ = employeeManagementEntities.Employees.FirstOrDefault(emp => emp.ID == employee.ID);

                employ.Name = employee.Name;
                employ.Designation = employee.Designation;
                employ.Experience = employee.Experience;
                employ.Salary = employee.Salary;
                employeeManagementEntities.Entry(employ).State = EntityState.Modified;
                employeeManagementEntities.SaveChanges();
            }
        }

        private bool isValidEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentException("Cannot update empty employee", "employee");
            }

            if(string.IsNullOrEmpty(employee.Name))
            {
                throw new ArgumentException("Employee Name cannot be blank", "Name");
            }
            else if (string.IsNullOrEmpty(employee.Designation))
            {
                throw new ArgumentException("Employee Designation cannot be blank", "Designation");
            }
            else if (employee.Experience < 0)
            {
                throw new ArgumentException("Employee Experience cannot be blank", "Experience");
            }
            else if (employee.Salary < 0d)
            {
                throw new ArgumentException("Employee Salary cannot be blank", "Salary");
            }

            return true;
        }
    }
}