using CEN4020_Website.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace CEN4020_Website.Pages.Reviews;
public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _db;
    public IEnumerable<Model.Review> Review { get; set; }
    public IndexModel(ApplicationDbContext db)
    {
        _db = db;
    }

    public void OnGet()
    {
        Review = _db.Review; //Automatically opens db connection and executes SQL queries
    }

    public ActionResult OnPostGenerateReport()
    {
        var builder = new StringBuilder();
        builder.AppendLine("ReviewID,AuthorID,FilenameOriginal,Filename,Title,Certification,Notes,AnalysisOfAlgorithms,Applications," + 
                           "Architecture,ArtificialIntelligence,ComputerEngineering,Curriculum,DataStructures,Databases,DistancedLearning,DistributedSystems,EthicalSocietalIssues," +
                           "FirstYearComputing,GenderIssues,GrantWriting,GraphicsImageProcessing,HumanComputerInteraction,LaboratoryEnvironments,Literacy,MathematicsInComputing," +
                           "Multimedia,NetworkingDataCommunications,NonMajorCourses,ObjectOrientedIssues,OperatingSystems,ParallelProcessing,Pedagogy,ProgrammingLanguages,Research," +
                           "Security,SoftwareEngineering,SystemsAnalysisAndDesign,UsingTechnologyInTheClassroom,WebAndInternetProgramming,Other,OtherDescription");
        //String formatStr = "{0,8:N0},{1,20},{2,13},{3,20},{4,25},{5,50},{6,20},{7,20},{8,8},{9,7:N0},{10,11:N0},{11,25}";
        foreach(var paper in _db.Review)
        {
            builder.AppendLine($"{paper.ReviewID},{paper.AuthorID},{paper.FilenameOriginal},{paper.Filename},{paper.Title},{paper.Certification},{paper.NotesToReviewers}," +
                                $"{paper.AnalysisOfAlgorithms},{paper.Applications},{paper.Architecture},{paper.ArtificialIntelligence},{paper.ComputerEngineering},{paper.Curriculum},{paper.DataStructures},{paper.Databases},{paper.DistanceLearning}," +
                                $"{paper.DistributedSystems},{paper.EthicalSocietalIssues},{paper.FirstYearComputing},{paper.GenderIssues},{paper.GrantWriting},{paper.GraphicsImageProcessing},{paper.HumanComputerInteraction},{paper.LaboratoryEnvironments}," +
                                $"{paper.Literacy},{paper.MathematicsInComputing},{paper.Multimedia},{paper.NetworkingDataCommunications},{paper.NonMajorCourses},{paper.ObjectOrientedIssues},{paper.OperatingSystems},{paper.ParallelsProcessing},{paper.Pedagogy}," +
                                $"{paper.ProgrammingLanguages},{paper.Research},{paper.Security},{paper.SoftwareEngineering},{paper.SystemsAnalysisAndDesign},{paper.UsingTechnologyInTheClassroom},{paper.WebAndInternetProgramming},{paper.Other},{paper.OtherDescription}");

            //builder.AppendFormat(formatStr, paper.ReviewID, paper.FirstName, paper.MiddleInitial, paper.LastName, paper.Affiliation, paper.Department, paper.Address, paper.City, paper.State, paper.ZipCode, paper.PhoneNumber, paper.EmailAddress);
            //builder.AppendLine();
        }
        return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "Reviews_Report.csv");
    }
}
