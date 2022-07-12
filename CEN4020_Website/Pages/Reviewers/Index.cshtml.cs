using CEN4020_Website.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;


/*
 *  INDEX FOR REVIEWERS
 */

namespace CEN4020_Website.Pages.Reviewers;

//Only admins can view this page
[Authorize(Policy = "AdminCredentialsRequired")]
public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _db;
    public IEnumerable<Model.Reviewer> Reviewer { get; set; } //Reviewer object

    //Database context
    public IndexModel(ApplicationDbContext db)
    {
        _db = db;
    }

    public void OnGet()
    {
        Reviewer = _db.Reviewer; //Automatically opens db connection and executes SQL queries
    }

    //Generate report button functionality. Allows the user to download a .csv file containing all Reviewer records
    public ActionResult OnPostGenerateReport()
    {
        var builder = new StringBuilder();
        builder.AppendLine("ReviewerID,FirstName,MiddleInitial,LastName,Affiliation,Department,Address,City,State,ZipCode,PhoneNumber,Email,AnalysisOfAlgorithms,Applications," + 
                           "Architecture,ArtificialIntelligence,ComputerEngineering,Curriculum,DataStructures,Databases,DistancedLearning,DistributedSystems,EthicalSocietalIssues," +
                           "FirstYearComputing,GenderIssues,GrantWriting,GraphicsImageProcessing,HumanComputerInteraction,LaboratoryEnvironments,Literacy,MathematicsInComputing," +
                           "Multimedia,NetworkingDataCommunications,NonMajorCourses,ObjectOrientedIssues,OperatingSystems,ParallelProcessing,Pedagogy,ProgrammingLanguages,Research," +
                           "Security,SoftwareEngineering,SystemsAnalysisAndDesign,UsingTechnologyInTheClassroom,WebAndInternetProgramming,Other,OtherDescription");
        foreach(var reviewer in _db.Reviewer)
        {
            builder.AppendLine($"{reviewer.ReviewerID},{reviewer.FirstName},{reviewer.MiddleInitial},{reviewer.LastName},{reviewer.Affiliation},{reviewer.Department},{reviewer.Address},{reviewer.City},{reviewer.State},{reviewer.ZipCode},{reviewer.PhoneNumber},{reviewer.EmailAddress}," +
                                $"{reviewer.AnalysisOfAlgorithms},{reviewer.Applications},{reviewer.Architecture},{reviewer.ArtificialIntelligence},{reviewer.ComputerEngineering},{reviewer.Curriculum},{reviewer.DataStructures},{reviewer.Databases},{reviewer.DistancedLearning}," +
                                $"{reviewer.DistributedSystems},{reviewer.EthicalSocietalIssues},{reviewer.FirstYearComputing},{reviewer.GenderIssues},{reviewer.GrantWriting},{reviewer.GraphicsImageProcessing},{reviewer.HumanComputerInteraction},{reviewer.LaboratoryEnvironments}," +
                                $"{reviewer.Literacy},{reviewer.MathematicsInComputing},{reviewer.Multimedia},{reviewer.NetworkingDataCommunications},{reviewer.NonMajorCourses},{reviewer.ObjectOrientedIssues},{reviewer.OperatingSystems},{reviewer.ParallelProcessing},{reviewer.Pedagogy}," +
                                $"{reviewer.ProgrammingLanguages},{reviewer.Research},{reviewer.Security},{reviewer.SoftwareEngineering},{reviewer.SystemsAnalysisAndDesign},{reviewer.UsingTechnologyInTheClassroom},{reviewer.WebAndInternetProgramming},{reviewer.Other},{reviewer.OtherDescription}");
        }
        return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "Reviewers_Report.csv");
    }
}
