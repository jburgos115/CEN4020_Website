using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace CEN4020_Website.Pages
{
    public class AuthorModel : PageModel
    {
        public List<PaperSubmission> listPaperSubmissions = new List<PaperSubmission>();
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
                                PaperSubmission paperSubmission               = new PaperSubmission();
                                paperSubmission.PaperID                       = reader.GetInt32(0);
                                paperSubmission.AuthorID                      = reader.GetInt32(1);
                                paperSubmission.Active                        = (bool)reader.GetSqlBoolean(2);
                                paperSubmission.FilenameOriginal              = reader.GetString(3);
                                paperSubmission.Filename                      = reader.GetString(4);
                                paperSubmission.title                         = reader.GetString(5);
                                paperSubmission.Certification                 = reader.GetString(6);
                                paperSubmission.NotesToReviewer               = reader.GetString(7);
                                paperSubmission.AnalysisOfAlgorithms          = (bool)reader.GetSqlBoolean(8);
                                paperSubmission.Applications                  = (bool)reader.GetSqlBoolean(8);
                                paperSubmission.Architecture                  = (bool)reader.GetSqlBoolean(9);
                                paperSubmission.ArtificialIntelligence        = (bool)reader.GetSqlBoolean(10);
                                paperSubmission.ComputerEngineering           = (bool)reader.GetSqlBoolean(11);
                                paperSubmission.Curriculum                    = (bool)reader.GetSqlBoolean(12);
                                paperSubmission.DataStructures                = (bool)reader.GetSqlBoolean(13);
                                paperSubmission.Databases                     = (bool)reader.GetSqlBoolean(14);
                                paperSubmission.DistanceLearning              = (bool)reader.GetSqlBoolean(15);
                                paperSubmission.DistributedSystems            = (bool)reader.GetSqlBoolean(16);
                                paperSubmission.EthicalSocietalIssues         = (bool)reader.GetSqlBoolean(17);
                                paperSubmission.FirstYearComputing            = (bool)reader.GetSqlBoolean(18);
                                paperSubmission.GenderIssues                  = (bool)reader.GetSqlBoolean(19);
                                paperSubmission.GrantWriting                  = (bool)reader.GetSqlBoolean(20);
                                paperSubmission.GraphicsImageProcessing       = (bool)reader.GetSqlBoolean(21);
                                paperSubmission.HumanComputerInteraction      = (bool)reader.GetSqlBoolean(22);
                                paperSubmission.LabratoryEnvironments         = (bool)reader.GetSqlBoolean(23);
                                paperSubmission.Literacy                      = (bool)reader.GetSqlBoolean(24);
                                paperSubmission.MathematicsInComputing        = (bool)reader.GetSqlBoolean(25);
                                paperSubmission.Multimedia                    = (bool)reader.GetSqlBoolean(26);
                                paperSubmission.NetworkingDataCommunications  = (bool)reader.GetSqlBoolean(27);
                                paperSubmission.NonMajorCourses               = (bool)reader.GetSqlBoolean(28);
                                paperSubmission.ObjectOrientedIssues          = (bool)reader.GetSqlBoolean(29);
                                paperSubmission.OperatingSystems              = (bool)reader.GetSqlBoolean(30);
                                paperSubmission.ParallelProcessing            = (bool)reader.GetSqlBoolean(31);
                                paperSubmission.Pedagogy                      = (bool)reader.GetSqlBoolean(32);
                                paperSubmission.ProgrammingLanguages          = (bool)reader.GetSqlBoolean(33);
                                paperSubmission.Research                      = (bool)reader.GetSqlBoolean(34);
                                paperSubmission.Security                      = (bool)reader.GetSqlBoolean(35);
                                paperSubmission.SoftwareEngineering           = (bool)reader.GetSqlBoolean(36);
                                paperSubmission.SystemsAnalysisAndDesign      = (bool)reader.GetSqlBoolean(37);
                                paperSubmission.UsingTechnologyInTheClassroom = (bool)reader.GetSqlBoolean(38);
                                paperSubmission.WebAndInternetProgramming     = (bool)reader.GetSqlBoolean(39);
                                paperSubmission.Other                         = (bool)reader.GetSqlBoolean(40);

                                listPaperSubmissions.Add(paperSubmission);

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


    public class PaperSubmission
    {
        public int PaperID;
        public int AuthorID;
        public bool Active;
        public string FilenameOriginal;
        public string Filename;
        public string title;
        public string Certification;
        public string NotesToReviewer;
        public bool AnalysisOfAlgorithms;
        public bool Applications;
        public bool Architecture;
        public bool ArtificialIntelligence;
        public bool ComputerEngineering;
        public bool Curriculum;
        public bool DataStructures;
        public bool Databases;
        public bool DistanceLearning;
        public bool DistributedSystems;
        public bool EthicalSocietalIssues;
        public bool FirstYearComputing;
        public bool GenderIssues;
        public bool GrantWriting;
        public bool GraphicsImageProcessing;
        public bool HumanComputerInteraction;
        public bool LabratoryEnvironments;
        public bool Literacy;
        public bool MathematicsInComputing;
        public bool Multimedia;
        public bool NetworkingDataCommunications;
        public bool NonMajorCourses;
        public bool ObjectOrientedIssues;
        public bool OperatingSystems;
        public bool ParallelProcessing;
        public bool Pedagogy;
        public bool ProgrammingLanguages;
        public bool Research;
        public bool Security;
        public bool SoftwareEngineering;
        public bool SystemsAnalysisAndDesign;
        public bool UsingTechnologyInTheClassroom;
        public bool WebAndInternetProgramming;
        public bool Other;

    }
}
