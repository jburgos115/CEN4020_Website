using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


/*
 *  UPLOAD FILE FOR AUTHORS
 */

namespace CEN4020_Website.Pages.Papers
{
    public class UploadModel : PageModel
    {
        private readonly IWebHostEnvironment _environment;
        public UploadModel(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        //Retrieves PaperID to attach to file upload
        public void OnGetPaperID(int PaperID)
        {
            TempData["id"] = PaperID;
        }

        //Controller for uploading a pdf file to wwwroot/Uploads folder as a custom named file
        public void OnPostUpload(List<IFormFile> postedFiles)
        {
            string myPath = this._environment.WebRootPath;
            string contentPath = this._environment.ContentRootPath;

            string path = Path.Combine(this._environment.WebRootPath, "Uploads");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            List<string> uploadedFiles = new List<string>();
            foreach (IFormFile postedFile in postedFiles)
            {
                string fileName = "Paper"+TempData["id"].ToString()+".pdf";
                using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                    uploadedFiles.Add(fileName);
                }
                TempData["success"] = "Uploaded Successfully";
            }
            Response.Redirect("Index");
        }
    }
}
