using CEN4020_Website.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CEN4020_Website.Pages.LoginRegister
{
    //Allows Author to Edit Their Profile
    [BindProperties]
    public class UserSettingAuthorModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Model.Author Author { get; set; }

        public UserSettingAuthorModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            Author = _db.Author.Find(id);
        }

        public async Task<IActionResult> OnPost(Model.Author author)
        {
            if (ModelState.IsValid)
            {
                _db.Author.Update(author);
                await _db.SaveChangesAsync();
                TempData["success"] = "Profile Edited Successfully";
                return Page();
            }
            return Page();

        }
    }
}
