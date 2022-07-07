using System.ComponentModel.DataAnnotations;

namespace CEN4020_Website.Model
{
	public class Author
	{
        public int AuthorID { get; set; }

        [Required(ErrorMessage = "Please provide first name", AllowEmptyStrings = false)]
        public string firstName { get; set; }

        [Required(ErrorMessage = "Please provide middle initial", AllowEmptyStrings = false)]
        public string middleInitial { get; set; }

        [Required(ErrorMessage = "Please provide last name", AllowEmptyStrings = false)]
        public string lastName { get; set; }

        [Required(ErrorMessage = "Please provide affiliation", AllowEmptyStrings = false)]
        public string affiliation { get; set; }

        [Required(ErrorMessage = "Please provide department", AllowEmptyStrings = false)]
        public string department { get; set; }

        [Required(ErrorMessage = "Please provide address", AllowEmptyStrings = false)]
        public string address { get; set; }

        [Required(ErrorMessage = "Please provide city", AllowEmptyStrings = false)]
        public string city { get; set; }

        [Required(ErrorMessage = "Please provide state", AllowEmptyStrings = false)]
        public string state { get; set; }

        [Required(ErrorMessage = "Please provide zip code", AllowEmptyStrings = false)]
        public string zipCode { get; set; }

        [Required(ErrorMessage = "Please provide phone number", AllowEmptyStrings = false)]
        public string phoneNumber { get; set; }

        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$",
        ErrorMessage = "Please provide valid email id")]
        public string emailAddress { get; set; }

        [Required(ErrorMessage = "Please provide Password", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password must be 8 char long.")]
        public string password { get; set; }
    }
}
