using EmployeeSite.Data.Context;
using EmployeeSite.Data.Entities;
using EmployeeSite.Utilities;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace EmployeeSite.Business
{
    public class ChangesTrackProvider : IChangesTrackProvider
    {
        private readonly EmployeeDbContext _employeeDb;

        public ChangesTrackProvider()
        {
            _employeeDb = new EmployeeDbContext();
        }

        public async Task LogChanges(Employee employee)
        {
            // Managers
            var employeeInfo = await GetEmployeeAsync(employee.Id);
            if (employeeInfo == null) return;
            var employeeActivity = new EmployeeActivity();
            if (!string.IsNullOrEmpty(employeeInfo.Manager) &&
               !string.IsNullOrEmpty(employee.Manager) &&
               employeeInfo.Manager != employee.Manager)
            {
                _employeeDb.EmployeeActivities.Add(new EmployeeActivity
                {
                    ChangeType = Constants.MANAGERS,
                    Date = DateTime.UtcNow,
                    EmployeeId = employeeInfo.Id,
                    NewValue = employee.Manager,
                    OldValue = employeeInfo.Manager
                });
            }

            // Title 
            if (!string.IsNullOrEmpty(employeeInfo.Position) &&
               !string.IsNullOrEmpty(employee.Position) &&
               employeeInfo.Position != employee.Position)
            {
                _employeeDb.EmployeeActivities.Add(new EmployeeActivity
                {
                    ChangeType = Constants.TITLE,
                    Date = DateTime.UtcNow,
                    EmployeeId = employeeInfo.Id,
                    NewValue = employee.Manager,
                    OldValue = employeeInfo.Manager
                });
            }

            // Permissions
            if (!string.IsNullOrEmpty(employeeInfo.Permissions) &&
               !string.IsNullOrEmpty(employee.Permissions) &&
               employeeInfo.Permissions != employee.Permissions)
            {
                _employeeDb.EmployeeActivities.Add(new EmployeeActivity
                {
                    ChangeType = Constants.PERMISSIONS,
                    Date = DateTime.UtcNow,
                    EmployeeId = employeeInfo.Id,
                    NewValue = employee.Manager,
                    OldValue = employeeInfo.Manager
                });
            }

            await _employeeDb.SaveChangesAsync();
        }

        public async Task<Employee> GetEmployeeAsync(int id)
        {
            return await _employeeDb.Employees.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}