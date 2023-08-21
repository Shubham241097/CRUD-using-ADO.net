using System.ComponentModel.DataAnnotations;

namespace FutureFacePractice.Models
{
    public class Student
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Enter First Name")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Enter Last Name")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Enter Your Email")]
        [DataType(DataType.EmailAddress)]   
        public string Email { get; set; }

        [Required(ErrorMessage = "Select Gender")]
        public string Gender { get; set; }
        public int? Age { get; set; }
        public string Address { get; set; }
        public int PinCode { get; set; }
        public string Course { get; set; }
        public string Center { get; set; }        
    }
}
