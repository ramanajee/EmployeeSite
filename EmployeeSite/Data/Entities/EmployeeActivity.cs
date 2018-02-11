using System;

namespace EmployeeSite.Data.Entities
{
    public class EmployeeActivity
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string ChangeType { get; set; }
        public string NewValue { get; set; }
        public string OldValue { get; set; }
        public DateTime Date { get; set; }
    }
}