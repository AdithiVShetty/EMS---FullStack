using DataAccessLayer;
using System.Collections.Generic;

namespace BusinessLogicLayer
{
    public class EmployeeService
    {
        private readonly EmployeeRepository _employeeRepository;
        public EmployeeService(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public void SaveEmployee(EmpProfile employee)
        {
            _employeeRepository.SaveEmployee(employee);
        }
        public IEnumerable<EmpProfile> GetAllEmployees()
        {
            return _employeeRepository.GetAllEmployees();
        }
        public EmpProfile GetEmployeeByCode(int empCode)
        {
            return _employeeRepository.GetEmployeeByCode(empCode);
        }
        public void UpdateEmpProfile(EmpProfile employee)
        {
            _employeeRepository.UpdateEmpProfile(employee);
        }
        public void DeleteEmpProfile(int empCode)
        {
            _employeeRepository.DeleteEmpProfile(empCode);
        }
    }
}