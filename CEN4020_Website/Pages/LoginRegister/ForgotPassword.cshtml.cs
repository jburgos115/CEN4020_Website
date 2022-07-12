using CEN4020_Website.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;

namespace CEN4020_Website.Pages.LoginRegister
{
    public class ForgotPasswordModel : PageModel
    {
        [BindProperty]
        public ForgotPasswordInfo ForgotPasswordInfo { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            int idNumber = 0;
            
            if (!ModelState.IsValid)
                return Page();

            try
            {
                using (SqlConnection connection = new SqlConnection("Server =.; Database = CPMS; Trusted_Connection = True"))
                {
                    connection.Open();
                    //Searches for User in Author Table
                    String myCommand = "SELECT* FROM Author WHERE EmailAddress = @EmailAddress";
                    SqlCommand cmd = new SqlCommand(myCommand, connection);

                    cmd.Parameters.Add("@EmailAddress", SqlDbType.NVarChar, 100).Value = ForgotPasswordInfo.Email;
                    idNumber = Convert.ToInt32(cmd.ExecuteScalar());

                    if (idNumber > 0)
                    {
                        MailMessage mm = new MailMessage();
                        mm.To.Add(ForgotPasswordInfo.Email);
                        mm.Subject = "Password Reset";
                        mm.Body = "Click this link to reset your password";
                        mm.IsBodyHtml = false;
                        mm.From = new MailAddress("");

                        SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                        client.EnableSsl = true;
                        client.UseDefaultCredentials = true;
                        await client.SendMailAsync(mm);
                }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Sorry but we are unable to process your request at the moment please try again after a couple of minutes",
                    ex.Message);
            }

            ModelState.AddModelError("", "Incorrect Email Address or Password");
            return Page();
        }
    }

    public class ForgotPasswordInfo
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }
    }

}
