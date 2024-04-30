﻿using System.ComponentModel.DataAnnotations;

namespace WebApi_MVCMediateRApp.ViewModels
{
    public class UpdateUserRequestModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Email { get; set; }
        public string? Designation { get; set; }
        public string? Roles { get; set; }
        public string? ReportingManager { get; set; }
        public string? Approver { get; set; }
        public string? DepartmentName { get; set; }
        public Boolean IsVendor { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
    }
}