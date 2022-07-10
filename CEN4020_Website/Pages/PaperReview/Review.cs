using System.ComponentModel.DataAnnotations;

namespace CEN4020_Website.Pages.PaperReview
{
    public class Review
    {
       
        [Key]
        public int ReviewID { get; set; }
        [Required]
        public int PaperID { get; set; }
        [Required]
        public int ReviewerID { get; set; }
        [Required]
        public int AppropriatenessOfTopic { get; set; }
        [Required]
        public int TimelinessOfTopic { get; set; }
        [Required]
        public int SupportiveEvidence { get; set; }
        [Required]
        public int TechnicalQuality { get; set; }
        [Required]
        public int ScopeOfCoverage { get; set; }
        [Required]
        public int CitationOfPreviousWork { get; set; }
        [Required]
        public int Originality { get; set; }
        [Required]
        public string ContentComments { get; set; }
        [Required]
        public int OrganizationOfPaper { get; set; }
        [Required]
        public int ClarityOfMainMessage { get; set; }
        [Required]
        public int Mechanics { get; set; }
        [Required]
        public string WrittenDocumentComments { get; set; }
        [Required]
        public int SuitabilityForPresentation { get; set; }
        [Required]
        public int PotentialInterestInTopic { get; set; }
        [Required]
        public string PotentialForOralPresentationComments { get; set; }
        [Required]
        public int OverallRating { get; set; }
        [Required]
        public string OverallRatingComments { get; set; }
        [Required]
        public int ComfortLevelTopic { get; set; }
        [Required]
        public int ComfortLevelAcceptability { get; set; }
        [Required]
        public bool Complete { get; set; }


    }
}
