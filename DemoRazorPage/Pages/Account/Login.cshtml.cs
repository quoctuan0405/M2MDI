using DemoRazorPage.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using DemoRazorPage.Data;

namespace DemoRazorPage.Pages.Auth
{
    [BindProperties]
    public class LoginModel : PageModel
    {
        private readonly ApplicationDBContext _dbContext;

        public User Account { get; set; }

        public LoginModel(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync() 
        {
            if (Account != null)
            {
                // Find user
                var user = _dbContext.Users
                            .Where(u => u.Username.Equals(Account.Username))
                            .FirstOrDefault();

                if (user != null)
                {
                    // Send back a cookie
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Username)
                    };

                    var identity = new ClaimsIdentity(claims, "myCookie");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync("myCookie", claimsPrincipal);

                    return RedirectToPage("/CarView/CarIndex");
                }
            }

            return Page();
        }
    }
}
