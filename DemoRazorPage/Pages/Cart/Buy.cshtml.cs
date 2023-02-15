using DemoRazorPage.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DemoRazorPage.Pages.Cart
{
    public class BuyModel : PageModel
    {
        private readonly ApplicationDBContext _dbContext;

        public BuyModel(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void OnGet()
        {
        }

        public async void OnPost()
        {
            // Begin transaction
            var transaction = _dbContext.Database.BeginTransaction();

            // Get current logged in user
            var user = _dbContext.Users
                        .Where(user => user.Username == User.Identity.Name)
                        .FirstOrDefault();

            // List carts to remove
            var cartsToRemove = _dbContext.Carts
                   .Include(cart => cart.Car)
                   .Where(cart => cart.UserId == user.Id)
                   .ToList();

            // List cars to update
            List<Model.Car> cars = new List<Model.Car>();
            for (int i = 0; i < cartsToRemove.Count; i++)
            {
                cartsToRemove[i].Car.Quantity -= cartsToRemove[i].Quantity;

                cars.Add(cartsToRemove[i].Car);
            }

            // Remove and update
            _dbContext.RemoveRange(cartsToRemove);
            _dbContext.UpdateRange(cars);

            _dbContext.SaveChanges();

            // Commit
            transaction.Commit();

            Response.Redirect("/CarView/CarIndex");
        }
    }
}
