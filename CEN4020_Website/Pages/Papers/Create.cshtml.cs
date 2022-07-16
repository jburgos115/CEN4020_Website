using CEN4020_Website.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using System.Security.Claims;


/*
 *  CREATE FOR PAPERS
 */

namespace CEN4020_Website.Pages.Papers
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Model.Paper Paper { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }

        //Controller for creating a new database record
        public async Task<IActionResult> OnPost(Model.Paper paper)
        {
            if (!User.HasClaim("PapersChair", "Admin"))
            {
                paper.AuthorID = int.Parse(User.FindFirst("UserId").Value); //input authorID from cookie
                paper.FilenameOriginal = "";
            }

            try
            {
                await _db.Paper.AddAsync(paper);
                await _db.SaveChangesAsync();
                TempData["success"] = "New Paper Created Successfully";
                return RedirectToPage("Upload", "PaperID", new { PaperID = paper.PaperID });
            }
            catch (Exception ex)
            {
                TempData["error"] = "Sorry, we are unable to process your request at this time. Please try again later.";
            }
            return RedirectToPage("Index");

            
            
        }
    }
}
