using System.ComponentModel.DataAnnotations;

namespace ManageUser_MVC_CRUD_ADO.NET.Models
{
    public class User
    {
        
        public int UserID { get; set; }

        [Required(ErrorMessage ="Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Mobile is required.")]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "Age is required.")]
        public int Age { get; set; }

        public string Address { get; set; }
        public List<Qualification> Qualifications { get; set; } // For one-to-many relationship
    }

}
