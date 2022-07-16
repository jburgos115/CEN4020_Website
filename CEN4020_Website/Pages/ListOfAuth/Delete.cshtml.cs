using CEN4020_Website.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


/*
 *  DELETE FOR AUTHORS
 */

namespace CEN4020_Website.Pages.ListOfAuth
{
    [Authorize(Policy = "AdminCredentialsRequired")]
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Model.Author Author { get; set; }

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }

        //Retrieves data from database for a specific id and populates respective UI assets
        public void OnGet(int id)
        {
            Author = _db.Author.Find(id);
        }

        //Controller to delete record from database
        public async Task<IActionResult> OnPost(Model.Author author)
        {
            var authorFromDb = _db.Author.Find(author.AuthorID);
            try
            {
                if (authorFromDb != null)
                {
                    _db.Author.Remove(authorFromDb);
                    await _db.SaveChangesAsync();
                    TempData["success"] = "Author Deleted Successfully";
                }
                else
                    throw new Exception();
            }
            catch (Exception ex)
            {
                TempData["error"] = "Sorry, we are unable to process your request at this time. Please try again later.";
            }
            return RedirectToPage("Index");
        }
    }
}
