using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_MVCMediatRApp.Entity
{
    public class User
    {
        //public int Id { get; set; }
        //public string? UserName { get; set; }
        //public string? Email { get; set; }
        //public string? Designation { get; set; }
        //public string? Roles { get; set; }
        //public string? ReportingManager { get; set; }
        //public string? Approver { get; set; }
        //public string? DepartmentName { get; set; }
        //public Boolean IsVendor { get; set; }
        //public string? Phone { get; set; }
        //public string? Password { get; set; }
        public int Id { get; set; }
        [StringLength(20)]
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Email { get; set; }
        public string? Designation { get; set; }
        public string? Roles { get; set; }
        public string? ReportingManager { get; set; }
        public string? Approver { get; set; }
        public string? DepartmentName { get; set; }
        public bool IsVendor { get; set; }
        [StringLength(15)]
        [Required]
        public string? Phone { get; set; }
        public string? Password { get; set; }
    }
}
