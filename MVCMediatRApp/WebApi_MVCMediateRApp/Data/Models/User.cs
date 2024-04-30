using System.ComponentModel.DataAnnotations;

namespace WebApi_MVCMediateRApp.Data.Models
{
    public class User
    {

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
