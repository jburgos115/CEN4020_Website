using CEN4020_Website.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;


/*
 *  INDEX FOR PAPERS
 */

namespace CEN4020_Website.Pages.Papers;

//Main user view for Authors
public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _db;
    public IEnumerable<Model.Paper> Paper { get; set; } //Paper objects
    //Database context
    public IndexModel(ApplicationDbContext db)
    {
        _db = db;
    }

    public void OnGet()
    {
        Paper = _db.Paper; //Automatically opens db connection and executes SQL queries
    }

    //Generate report button functionality. Allows the user to download a .csv file containing all Paper records
    public ActionResult OnPostGenerateReport()
    {
        var builder = new StringBuilder();
        builder.AppendLine("PaperID,AuthorID,FilenameOriginal,Filename,Title,Certification,Notes,AnalysisOfAlgorithms,Applications," + 
                           "Architecture,ArtificialIntelligence,ComputerEngineering,Curriculum,DataStructures,Databases,DistancedLearning,DistributedSystems,EthicalSocietalIssues," +
                           "FirstYearComputing,GenderIssues,GrantWriting,GraphicsImageProcessing,HumanComputerInteraction,LaboratoryEnvironments,Literacy,MathematicsInComputing," +
                           "Multimedia,NetworkingDataCommunications,NonMajorCourses,ObjectOrientedIssues,OperatingSystems,ParallelProcessing,Pedagogy,ProgrammingLanguages,Research," +
                           "Security,SoftwareEngineering,SystemsAnalysisAndDesign,UsingTechnologyInTheClassroom,WebAndInternetProgramming,Other,OtherDescription");
        foreach(var paper in _db.Paper)
        {
            builder.AppendLine($"{paper.PaperID},{paper.AuthorID},{paper.FilenameOriginal},{paper.Filename},{paper.Title},{paper.Certification},{paper.NotesToReviewers}," +
                                $"{paper.AnalysisOfAlgorithms},{paper.Applications},{paper.Architecture},{paper.ArtificialIntelligence},{paper.ComputerEngineering},{paper.Curriculum},{paper.DataStructures},{paper.Databases},{paper.DistanceLearning}," +
                                $"{paper.DistributedSystems},{paper.EthicalSocietalIssues},{paper.FirstYearComputing},{paper.GenderIssues},{paper.GrantWriting},{paper.GraphicsImageProcessing},{paper.HumanComputerInteraction},{paper.LaboratoryEnvironments}," +
                                $"{paper.Literacy},{paper.MathematicsInComputing},{paper.Multimedia},{paper.NetworkingDataCommunications},{paper.NonMajorCourses},{paper.ObjectOrientedIssues},{paper.OperatingSystems},{paper.ParallelsProcessing},{paper.Pedagogy}," +
                                $"{paper.ProgrammingLanguages},{paper.Research},{paper.Security},{paper.SoftwareEngineering},{paper.SystemsAnalysisAndDesign},{paper.UsingTechnologyInTheClassroom},{paper.WebAndInternetProgramming},{paper.Other},{paper.OtherDescription}");

        }
        return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "Papers_Report.csv");
    }
}
