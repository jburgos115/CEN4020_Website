using CEN4020_Website.Data;
using Microsoft.AspNetCore.Identity.UI.Services;
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
        private readonly IEmailSender _emailSender;
        [BindProperty]
        public ForgotPasswordInfo ForgotPasswordInfo { get; set; }
        public ForgotPasswordModel(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            TempData["Author"] = "false";
            TempData["Reviewer"] = "false";
            if (!ModelState.IsValid)
                return Page();

            try
            {
                using (SqlConnection connection = new SqlConnection("Server =.; Database = CPMS; Trusted_Connection = True"))
                {
                    connection.Open();
                    //Searches for User in Author Table
                    String myCommand = "SELECT* FROM Author WHERE EmailAddress = @EmailAddress ";
                    SqlCommand cmd = new SqlCommand(myCommand, connection);

                    cmd.Parameters.Add("@EmailAddress", SqlDbType.NVarChar, 100).Value = ForgotPasswordInfo.Email;
                    int idNumber = Convert.ToInt32(cmd.ExecuteScalar());

                    if (idNumber > 0)
                    {
                        string emailResetCode = "Use this code to reset password 98";
                        await _emailSender.SendEmailAsync(ForgotPasswordInfo.Email, "Password Reset", emailResetCode);
                        TempData["Password"] = idNumber;
                        TempData["Author"] = "true";
                        return RedirectToPage("/LoginRegister/ConfirmationCode");
                    }

                    //Searches for User in Reviewer Table if not found in Author
                    myCommand = "SELECT* FROM Reviewer WHERE EmailAddress = @EmailAddress ";
                    cmd = new SqlCommand(myCommand, connection);

                    cmd.Parameters.Add("@EmailAddress", SqlDbType.NVarChar, 100).Value = ForgotPasswordInfo.Email;
                    idNumber = Convert.ToInt32(cmd.ExecuteScalar());

                    if (idNumber > 0)
                    {
                        string emailResetCode = "Use this code to reset password 98";
                        await _emailSender.SendEmailAsync(ForgotPasswordInfo.Email, "Password Reset", emailResetCode);
                        TempData["Password"] = idNumber;
                        TempData["Reviewer"] = "true";
                        return RedirectToPage("/LoginRegister/ConfirmationCode");
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Sorry but we are unable to process your request at the moment please try again after a couple of minutes",
                    ex.Message);
            }

            ModelState.AddModelError("", "Incorrect Email Address");
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
