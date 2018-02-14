using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmployeeSite.Data.Entities
{
    public class PermissionTie
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Permission")]
        public int EmployeeId { get; set; }
        [ForeignKey("Employee")]
        public int PermissionId { get; set; }
        public virtual Permission Permission { get; set; }
        public virtual Employee Employee { get; set; }
    }
}