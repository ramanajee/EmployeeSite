using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeSite.Data.Entities
{
    public class Department
    {
        [Key, ForeignKey("Employee")]
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public virtual Employee Employee { get; set; }
    }
}