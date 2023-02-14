using DemoRazorPage.Data;
using DemoRazorPage.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DemoRazorPage.Pages.CarView
{
    public class AddToCartModel : PageModel
    {
        public User Account { get; set; }
        private readonly ApplicationDBContext _dbContext;

        public AddToCartModel(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task OnGet(int id, int quantity)
        {
            Account = _dbContext.Users
                .Where(user => user.Username.Equals(User.Identity.Name))
                .Include(user => user.Carts)
                .ThenInclude(cart => cart.Car)
                .FirstOrDefault();
        }
    }
}
