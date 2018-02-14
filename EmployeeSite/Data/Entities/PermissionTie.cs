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
        [Key, ForeignKey("Permission")]
        public int EmployeeId { get; set; }
        [Key, ForeignKey("Employee")]
        public int PermissionId { get; set; }
    }
}