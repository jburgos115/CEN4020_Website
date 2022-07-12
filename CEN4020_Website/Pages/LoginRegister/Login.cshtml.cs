using CEN4020_Website.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Security.Claims;

namespace CEN4020_Website.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public LoginInfo LoginInfo { get; set; }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            //Hard Coded Admin Login
            if (LoginInfo.Email == "admin@cpms.com" && LoginInfo.Password == "admin")
            {
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, "admin"),
                    new Claim(ClaimTypes.Email, "admin@cpms.com"),
                    new Claim("PapersChair", "Admin")
                };

                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

                return RedirectToPage("/Index");
            }
            
            //Checking Login credentials against data in Author and Reviewer Table
            try
            {
                using (SqlConnection connection = new SqlConnection("Server =.; Database = CPMS; Trusted_Connection = True"))
                {
                    connection.Open();
                    //Searches for User in Author Table
                    String myCommand = "SELECT* FROM Author WHERE EmailAddress = @EmailAddress AND Password = @Password ";
                    SqlCommand cmd = new SqlCommand(myCommand, connection);

                    cmd.Parameters.Add("@EmailAddress", SqlDbType.NVarChar, 100).Value = LoginInfo.Email;
                    cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 5).Value = LoginInfo.Password;
                    int idNumber = Convert.ToInt32(cmd.ExecuteScalar());

                    if (idNumber > 0)
                    {
                        var claims = new List<Claim> {
                            new Claim(ClaimTypes.Name, LoginInfo.Email),
                            new Claim(ClaimTypes.Email, LoginInfo.Email),
                            new Claim("UserAuthor", "Author")
                        };

                        var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                        await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

                        return RedirectToPage("/Index");
                    }
                    //Searches for User in Reviewer Table if not found in Author Table
                    myCommand = "SELECT* FROM Reviewer WHERE EmailAddress = @EmailAddress AND Password = @Password ";
                    cmd = new SqlCommand(myCommand, connection);

                    cmd.Parameters.Add("@EmailAddress", SqlDbType.NVarChar, 100).Value = LoginInfo.Email;
                    cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 5).Value = LoginInfo.Password;
                    idNumber = Convert.ToInt32(cmd.ExecuteScalar());

                    if (idNumber > 0)
                    {
                        var claims = new List<Claim> {
                            new Claim(ClaimTypes.Name, LoginInfo.Email),
                            new Claim(ClaimTypes.Email, LoginInfo.Email),
                            new Claim("UserReviewer", "Reviewer")
                        };

                        var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                        await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

                        return RedirectToPage("/Index");
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

    public class LoginInfo
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
