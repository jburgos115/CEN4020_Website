using System.ComponentModel.DataAnnotations;

namespace CEN4020_Website.Model
{
    public class Author
    {
        [Key]
        public int AuthorID { get; set; }
        [Required(ErrorMessage = "Please provide a First Name", AllowEmptyStrings = false)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please provide a Middle Initial", AllowEmptyStrings = false)]
        public string MiddleInitial { get; set; }

        [Required(ErrorMessage = "Please provide a Last Name", AllowEmptyStrings = false)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please provide Affiliation", AllowEmptyStrings = false)]
        public string Affiliation { get; set; }

        [Required(ErrorMessage = "Please provide Department", AllowEmptyStrings = false)]
        public string Department { get; set; }

        [Required(ErrorMessage = "Please provide Address", AllowEmptyStrings = false)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please provide City", AllowEmptyStrings = false)]
        public string City { get; set; }

        [Required(ErrorMessage = "Please provide State", AllowEmptyStrings = false)]
        public string State { get; set; }

        [Required(ErrorMessage = "Please provide Zip Code", AllowEmptyStrings = false)]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Please provide Phone Number", AllowEmptyStrings = false)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please provide an Email Address", AllowEmptyStrings = false)]
        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$",
        ErrorMessage = "Please provide a valid Email Address")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Please provide a Password", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "Password must be 5 char long.")]
        public string Password { get; set; }

    }
}

