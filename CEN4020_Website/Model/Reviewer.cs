using System.ComponentModel.DataAnnotations;

namespace CEN4020_Website.Model
{
    //declares the attributes of reviewer table
    //these variables are used to register keep records of reviewers in the database
    public class Reviewer
    {
        [Key]
        public int ReviewerID { get; set; }

        //[Required(ErrorMessage = "Please provide activity status", AllowEmptyStrings = false)]
        //public string Active { get; set; }

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
        //[DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "Password must be 5 char long.")]
        public string Password { get; set; }

        public bool AnalysisOfAlgorithms { get; set; }
                
		public bool Applications { get; set; }
                
		public bool Architecture { get; set; }
                
		public bool ArtificialIntelligence { get; set; }
                
		public bool ComputerEngineering { get; set; }
                
		public bool Curriculum { get; set; }
                
		public bool DataStructures { get; set; }
                
		public bool Databases { get; set; }
                
		public bool DistancedLearning { get; set; }
                
		public bool DistributedSystems { get; set; }
                
		public bool EthicalSocietalIssues { get; set; }
                
		public bool FirstYearComputing { get; set; }
                
		public bool GenderIssues { get; set; }
                
		public bool GrantWriting { get; set; }
                
		public bool GraphicsImageProcessing { get; set; }
                
		public bool HumanComputerInteraction { get; set; }
                
		public bool LaboratoryEnvironments { get; set; }
                
		public bool Literacy { get; set; }
                
		public bool MathematicsInComputing { get; set; }
                
		public bool Multimedia { get; set; }
                
		public bool NetworkingDataCommunications { get; set; }
                
		public bool NonMajorCourses { get; set; }
                
		public bool ObjectOrientedIssues { get; set; }
                
		public bool OperatingSystems { get; set; }
                
		public bool ParallelProcessing { get; set; }
                
		public bool Pedagogy { get; set; }
                
		public bool ProgrammingLanguages { get; set; }
                
		public bool Research { get; set; }
                
		public bool Security { get; set; }
                
		public bool SoftwareEngineering { get; set; }
                
		public bool SystemsAnalysisAndDesign { get; set; }
                
		public bool UsingTechnologyInTheClassroom { get; set; }
                
		public bool WebAndInternetProgramming { get; set; }
                
		public bool Other { get; set; }

		public string OtherDescription { get; set; }

    }
}
