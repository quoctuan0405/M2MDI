using DemoRazorPage.Data;
using DemoRazorPage.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DemoRazorPage.Pages.Cart
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDBContext _dbContext;

        public CreateModel(ApplicationDBContext db)
        {
            _dbContext = db;
        }
         
        public async Task<IActionResult> OnGet()
        {
            return RedirectToPage("/Cart/Index");
        }
        
        public void OnPost(int carId)
        {
            var user = _dbContext.Users
                                .Where(user => user.Username == User.Identity.Name)
                                .FirstOrDefault();

            var cart = _dbContext.Carts
                        .Where(cart => cart.CarId == carId && cart.UserId == user.Id)
                        .FirstOrDefault();

            if (cart == null)
            {
                cart = new Model.Cart()
                {
                    CarId = carId,
                    UserId = user.Id,
                    Quantity = 1,
                };

                _dbContext.Add(cart);
            }
            else
            {
                cart.Quantity++;

                _dbContext.Update(cart);
            }

             _dbContext.SaveChanges();

            Response.Redirect("/Cart/Index");
        }
    }
}
