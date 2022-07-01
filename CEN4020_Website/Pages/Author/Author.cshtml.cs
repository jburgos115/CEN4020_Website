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
                using (SqlConnection connection = new SqlConnection(/*connectionString*/))
                {
                    connection.Open();
                    String sql = "SELECT * FROM Author";
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PaperSubmission paperSubmission               = new PaperSubmission();
                                paperSubmission.title                         = reader.GetString(0);
                                paperSubmission.AnalysisOfAlgorithms          = (bool)reader["AnalysisOfAlgorithms"];
                                paperSubmission.Applications                  = (bool)reader["Applications"];
                                paperSubmission.Architecture                  = (bool)reader["Architecture"];
                                paperSubmission.ArtificialIntelligence        = (bool)reader["ArtificialIntelligence"];
                                paperSubmission.ComputerEngineering           = (bool)reader["ComputerEngineering"];
                                paperSubmission.Curriculum                    = (bool)reader["Curriculum"];
                                paperSubmission.DataStructures                = (bool)reader["DataStructures"];
                                paperSubmission.Databases                     = (bool)reader["Databases"];
                                paperSubmission.DistanceLearning              = (bool)reader["DistanceLearning"];
                                paperSubmission.DistributedSystems            = (bool)reader["DistributedSystems"];
                                paperSubmission.EthicalSocietalIssues         = (bool)reader["EthicalSocietalIssues"];
                                paperSubmission.FirstYearComputing            = (bool)reader["FirstYearComputing"];
                                paperSubmission.GenderIssues                  = (bool)reader["GenderIssues"];
                                paperSubmission.GrantWriting                  = (bool)reader["GrantWriting"];
                                paperSubmission.GraphicsImageProcessing       = (bool)reader["GraphicsImageProcessing"];
                                paperSubmission.HumanComputerInteraction      = (bool)reader["HumanComputerInteraction"];
                                paperSubmission.LabratoryEnvironments         = (bool)reader["LabratoryEnvironments"];
                                paperSubmission.Literacy                      = (bool)reader["Literacy"];
                                paperSubmission.MathematicsInComputing        = (bool)reader["MathematicsInComputing"];
                                paperSubmission.Multimedia                    = (bool)reader["Multimedia"];
                                paperSubmission.NetworkingDataCommunications  = (bool)reader["NetworkingDataCommunications"];
                                paperSubmission.NonMajorCourses               = (bool)reader["NonMajorCourses"];
                                paperSubmission.ObjectOrientedIssues          = (bool)reader["ObjectOrientedIssues"];
                                paperSubmission.OperatingSystems              = (bool)reader["OperatingSystems"];
                                paperSubmission.ParallelProcessing            = (bool)reader["ParallelProcessing"];
                                paperSubmission.Pedagogy                      = (bool)reader["Pedagogy"];
                                paperSubmission.ProgrammingLanguages          = (bool)reader["ProgrammingLanguages"];
                                paperSubmission.Research                      = (bool)reader["Research"];
                                paperSubmission.Security                      = (bool)reader["Security"];
                                paperSubmission.SoftwareEngineering           = (bool)reader["SoftwareEngineering"];
                                paperSubmission.SystemsAnalysisAndDesign      = (bool)reader["SystemsAnalysisAndDesign"];
                                paperSubmission.UsingTechnologyInTheClassroom = (bool)reader["UsingTechnologyInTheClassroom"];
                                paperSubmission.WebAndInternetProgramming     = (bool)reader["WebAndInternetProgramming"];
                                paperSubmission.Other                         = (bool)reader["Other"];

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
        public string title;
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
