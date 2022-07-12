using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;

namespace CEN4020_Website.Pages
{
    public class DownloadFileModel : PageModel
    {
        public List<GetFile> Files { get; set; }
        private readonly IWebHostEnvironment _webHostEnvironment;
        public DownloadFileModel( IWebHostEnvironment webHostEnvironment)
        {
            
           this._webHostEnvironment = webHostEnvironment;
        }

        public void OnGet()
        {
            string[] files = Directory.GetFiles(Path.Combine(this._webHostEnvironment.WebRootPath, "Files/"));

            this.Files = new List<GetFile>();
            foreach(string file in files)
            {
                this.Files.Add(new GetFile {FileName = Path.GetFileName(file)});
            }
        }
        public FileResult OnGetDownload(string filename)
        {
            string path = Path.Combine(this._webHostEnvironment.WebRootPath, "Files/") + filename;
            byte[] buffer = System.IO.File.ReadAllBytes(path);
            return File(buffer, "application/octet-stream", filename);
        }
    }
}
