using System.Collections.Generic;
using Xunit;

using EmployeeManagementSystem;
using EmployeeManagementSystem.Services;
using WebApplication1;

namespace EmployeeManagementSystemTest.ServicesTest
{
    public class EmployeeServiceTest
    {
        [Fact]
        public void GetEmployeeByIDTest()
        {
            //Arrange
            int id = 1;
            int expected = 1;
            IEmployeeService employeeService = new EmployeeService();

            //Act
            Employee employeesActual = employeeService.GetEmployee(id);

            //Assert
            Assert.IsType<Employee>(employeesActual);
            Assert.Equal(expected, employeesActual.ID);
        }

        [Fact]
        public void GetEmployessTest()
        {
            //Arrange

            IEmployeeService employeeService = new EmployeeService();

            //Act
            List<Employee> employeesActual = employeeService.GetEmployees();

            //Assert
            Assert.IsType<List<Employee>>(employeesActual);
        }

        [Fact]
        public void AddEmployeesTest()
        {
            //Arrange
            Employee employeeOne = new Employee()
            {
                Name = "Bijay K.",
                Designation = "Angular Developer",
                Experience = 1,
                Salary = 30000.0d
            };

            Employee employeeTwo = new Employee()
            {
                Name = "Bijay Kumar Yadav",
                Designation = ".NET Developer",
                Experience = 1,
                Salary = 10000.0d
            };

            Employee employeeThree = new Employee()
            {
                Name = "Sujesh",
                Designation = "Android Developer",
                Experience = 1,
                Salary = 40000.0d
            };

            IEmployeeService employeeService = new EmployeeService();

            //Act
            employeeService.AddEmployee(employeeOne);
            employeeService.AddEmployee(employeeTwo);
            employeeService.AddEmployee(employeeThree);

            //Assert
        }

        [Fact]
        public void DeleteEmployeeTest()
        {
            //Arrange
            int id = 1;
            bool expected = true;

            IEmployeeService employeeService = new EmployeeService();

            //Act
            bool actual = employeeService.DeleteEmployee(id);

            //Assert
            Assert.True(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void UpdateEmployeeTest()
        {
            //Arrange
            Employee employeeOne = new Employee()
            {
                ID = 1,
                Name = "Dinesh K.",
                Designation = "Java Developer",
                Experience = 20,
                Salary = 1000000.0d
            };

            IEmployeeService employeeService = new EmployeeService();

            //Act
             employeeService.UpdateEmployee(employeeOne);

            //Assert
           
        }
    }
}
