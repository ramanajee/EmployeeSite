using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmployeeSite.Data.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Position { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string EmploymentStatus { get; set; }
        public string Shift { get; set; }
        public string Manager { get; set; }
        public string ImageFileName { get; set; }
        public string FavoriteColor { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Department DepartmentId { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; }
    }



}