using System.ComponentModel.DataAnnotations;

namespace CEN4020_Website.Model
{
    //declares the attributes of review table
    //these variables are used to register keep records of reviews in the database
    public class Review
    {
        [Key]
        public int ReviewID { get; set; }

        //[Required(ErrorMessage = "Please provide activity status", AllowEmptyStrings = false)]
        //public string Active { get; set; }

        public int PaperID { get; set; }

        public int ReviewerID { get; set; }

        public decimal AppropriatenessOfTopic { get; set; }

        public decimal TimelinessOfTopic { get; set; }

        [Required(ErrorMessage = "Please provide Supportive Evidence")]
        public decimal SupportiveEvidence { get; set; }
        
        //[Required(ErrorMessage = "Please provide Certification", AllowEmptyStrings = false)]
        public decimal TechnicalQuality { get; set; }

        public decimal ScopeOfCoverage { get; set; }

        public decimal CitationOfPreviousWork { get; set; }
                
		public decimal Originality { get; set; }
                
		public string ContentComments { get; set; }
                
		public decimal OrganizationOfPaper { get; set; }
                
		public decimal ClarityOfMainMessage { get; set; }
                
		public decimal Mechanics { get; set; }
                
		public string WrittenDocumentComments { get; set; }
                
		public decimal SuitabilityForPresentation { get; set; }
                
		public decimal PotentialInterestInTopic { get; set; }
                
		public string PotentialForOralPresentationComments { get; set; }
                
		public decimal OverallRating { get; set; }
                
		public string OverallRatingComments { get; set; }
                
		public decimal ComfortLevelTopic { get; set; }
                
		public decimal ComfortLevelAcceptability { get; set; }
                
		public bool Complete { get; set; }

    }
}
