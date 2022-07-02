using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
namespace CEN4020_Website.Pages.Reviews
{
    public class ReviewModel : PageModel
    {
        public List<PaperReview> listPaperReview = new List<PaperReview>();
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=CPMS;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM Paper";
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PaperReview paperReview = new PaperReview();
                                paperReview.PaperID = reader.GetInt32(0);
                                paperReview.AuthorID = reader.GetInt32(1);
                                paperReview.ReviewerID = reader.GetInt32(2);
                                paperReview.AppropriatenessOfTopic = reader.GetDecimal(3);
                                paperReview.TimelinessOfTopic = reader.GetDecimal(4);
                                paperReview.SupportiveEvidence= reader.GetDecimal(5);
                                paperReview.TechniccalQuality = reader.GetDecimal(6);
                                paperReview.ScopOfCoverage = reader.GetDecimal(7);
                                paperReview.CitationOfPreviousWork = reader.GetDecimal(8);
                                paperReview.Originality = reader.GetDecimal(9);
                                paperReview.ContentComments = reader.GetChar(10);
                                paperReview.OrganizationOfPaper = reader.GetDecimal(11);
                                paperReview.ClarityOfMessage = reader.GetDecimal(12);
                                paperReview.Mechanics = reader.GetDecimal(13);
                                paperReview.WrittenDocumentsComments = reader.GetChar(14);
                                paperReview.SuitabilityForPresentation = reader.GetDecimal(15);
                                paperReview.PotentialInterestInTopic = reader.GetDecimal(16);
                                paperReview.PotentialForOralPresentationComments = reader.GetChar(17);
                                paperReview.OverallRating = reader.GetDecimal(18);
                                paperReview.OverallRatingComments = reader.GetDecimal(19);
                                paperReview.ComfortLevelTopic = reader.GetDecimal(20);
                                paperReview.ComfortLevelAcceptability = reader.GetDecimal(21);
                                paperReview.Complete = (bool)reader.GetSqlBoolean(21);
                                

                                listPaperReview.Add(paperReview);

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }
    }


    public class PaperReview
    {
        public int PaperID;
        public int AuthorID;
        public int ReviewerID;
        public decimal AppropriatenessOfTopic;
        public decimal TimelinessOfTopic;
        public decimal SupportiveEvidence;
        public decimal TechniccalQuality;
        public decimal ScopOfCoverage;
        public decimal CitationOfPreviousWork;
        public decimal Originality;
        public char ContentComments;
        public decimal OrganizationOfPaper;
        public decimal ClarityOfMessage;
        public decimal Mechanics;
        public char WrittenDocumentsComments;
        public decimal SuitabilityForPresentation ;
        public decimal PotentialInterestInTopic;
        public char PotentialForOralPresentationComments;
        public decimal OverallRating;
        public decimal OverallRatingComments;
        public decimal ComfortLevelTopic ;
        public decimal ComfortLevelAcceptability ;
        public bool Complete ;

    }
}
        
    

