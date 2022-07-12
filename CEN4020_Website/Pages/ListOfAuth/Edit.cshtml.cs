using CEN4020_Website.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

/*
 *  EDIT FOR AUTHORS
 */

namespace CEN4020_Website.Pages.ListOfAuth
{
    //Only admin can view
    [Authorize(Policy = "AdminCredentialsRequired")]
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Model.Author Author { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        //Retrieves data from database for a specific id and populates respective UI assets
        public void OnGet(int id)
        {
            Author = _db.Author.Find(id);
        }

        //Controller to save changes
        public async Task<IActionResult> OnPost(Model.Author author)
        {
            if (ModelState.IsValid)
            {
                _db.Author.Update(author);
                await _db.SaveChangesAsync();
                TempData["success"] = "Author Edited Successfully";
                return RedirectToPage("Index");
            }
            return Page();

        }
    }
}
