namespace WebApi_MVCMediateRApp.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; } = 0;
        public string? UserName { get; set; } = "Sunil Chhatbar";
        public string? Email { get; set; } = "chhatbarsunil@gmail.com";
        public string? Designation { get; set; }
        public string? Roles { get; set; }
        public string? ReportingManager { get; set; }
        public string? Approver { get; set; }
        public string? DepartmentName { get; set; }
        public Boolean IsVendor { get; set; }
        public string? Phone { get; set; }
    }
}
