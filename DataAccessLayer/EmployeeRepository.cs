using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataAccessLayer
{
    public class EmployeeRepository
    {
        private readonly EMSDbContext _context;

        public EmployeeRepository(EMSDbContext context)
        {
            _context = context;
        }
        public void SaveEmployee(EmpProfile employee)
        {
            var deptMaster = _context.DeptMasters.SingleOrDefault(d => d.DeptCode == employee.DeptCode);
            if (deptMaster != null)
            {
                employee.DeptMaster = deptMaster;
                _context.EmpProfiles.Add(employee);
                _context.SaveChanges();
            }
        }
        public IEnumerable<EmpProfile> GetAllEmployees()
        {
            return _context.EmpProfiles.Include(e => e.DeptMaster).ToList();
        }
        public EmpProfile GetEmployeeByCode(int empCode)
        {
            return _context.EmpProfiles.Include(e => e.DeptMaster).FirstOrDefault(e => e.EmpCode == empCode);
        }
        public void UpdateEmpProfile(EmpProfile employee)
        {
            var deptMaster = _context.DeptMasters.SingleOrDefault(d => d.DeptCode == employee.DeptCode);
            if (deptMaster != null)
            {
                employee.DeptMaster = deptMaster;
                _context.Entry(employee).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
        public void DeleteEmpProfile(int empCode)
        {
            var employee = _context.EmpProfiles.Find(empCode);
            if (employee != null)
            {
                _context.EmpProfiles.Remove(employee);
                _context.SaveChanges();
            }
        }
    }
}