using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;


namespace CEN4020_Website.Pages
{
    public class UploadFileModel : PageModel
    {
        private readonly IWebHostEnvironment _environment;
        public UploadFileModel(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public void OnGet()
        {

        }
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
                string fileName = Path.GetFileName(postedFile.FileName);
                using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                    uploadedFiles.Add(fileName);
                    TempData["success"] = "Uploaded Successfully";
                }
            }
        }
    }
}
