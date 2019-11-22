using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_CRUD_DI_Entity.Models
{
    public class MockEmployeeRepository: IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee(){EmpCode = "101",EmployeeId =9, FullName = "Sancho",OfficeLocation = "Easton", Position="High"},
                new Employee(){EmpCode = "102",EmployeeId =12, FullName = "Panso",OfficeLocation = "Castilla", Position="Low"}
            };
        }

        public Employee GetEmployee(int Id)
        {
            return _employeeList.FirstOrDefault(e => e.EmployeeId == Id);
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _employeeList;
        }

        public Employee Add(Employee employee)
        {
            employee.EmployeeId = _employeeList.Max(e => e.EmployeeId) + 1;
            _employeeList.Add(employee);
            return employee;
        }

        public Employee Update(Employee employeeChanges)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.EmployeeId == employeeChanges.EmployeeId);
            if (employee != null)
            {
                employee.FullName = employeeChanges.FullName;
                employee.EmpCode = null;
                employee.OfficeLocation = employeeChanges.OfficeLocation;
                employee.Position = employeeChanges.Position;
            }

            return employee;
        }

        public Employee Delete(int id)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.EmployeeId == id);
            if (employee == null)
            {
                _employeeList.Remove(employee);
            }

            return employee;
        }
    }
}
