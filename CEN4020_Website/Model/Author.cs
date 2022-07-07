using System.ComponentModel.DataAnnotations;

namespace CEN4020_Website.Model
{
    public class Author
    {
        [Key]
        public int AuthorID { get; set; }
        [Required(ErrorMessage = "Please provide first name", AllowEmptyStrings = false)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please provide middle initial", AllowEmptyStrings = false)]
        public string MiddleInitial { get; set; }

        [Required(ErrorMessage = "Please provide last name", AllowEmptyStrings = false)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please provide affiliation", AllowEmptyStrings = false)]
        public string Affiliation { get; set; }

        [Required(ErrorMessage = "Please provide department", AllowEmptyStrings = false)]
        public string Department { get; set; }

        [Required(ErrorMessage = "Please provide address", AllowEmptyStrings = false)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please provide city", AllowEmptyStrings = false)]
        public string City { get; set; }

        [Required(ErrorMessage = "Please provide state", AllowEmptyStrings = false)]
        public string State { get; set; }

        [Required(ErrorMessage = "Please provide zip code", AllowEmptyStrings = false)]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Please provide phone number", AllowEmptyStrings = false)]
        public string PhoneNumber { get; set; }

        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$",
        ErrorMessage = "Please provide valid email id")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Please provide Password", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "Password must be 5 char long.")]
        public string Password { get; set; }

    }
}
