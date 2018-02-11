using System;
using System.ComponentModel;

namespace EmployeeSite.ViewModels
{
    public class ReportVm
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        [DisplayName("Change")]
        public string ChangeType { get; set; }
        [DisplayName("New Value")]
        public string NewValue { get; set; }
        [DisplayName("Old Value")]
        public string OldValue { get; set; }
        public DateTime Date { get; set; }
        [DisplayName("Employee Name")]
        public string EmployeeName { get; set; }

    }
}