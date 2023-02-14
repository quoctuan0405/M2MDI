using DemoRazorPage.Data;
using DemoRazorPage.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DemoRazorPage.Pages.Cart
{
    [BindProperties]
    public class UpdateModel : PageModel
    {
       
        private readonly ApplicationDBContext _dbContext;
        public DemoRazorPage.Model.Cart Cart { get; set; }

        public UpdateModel(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void OnGet(int id)
        {
           Cart = _dbContext.Carts
                    .Include(cart => cart.Car)
                    .FirstOrDefault(x => x.Id == id);
        }
        public void OnPost()
        {
            var user = _dbContext.Users.Where(user => user.Username == User.Identity.Name).FirstOrDefault();
            Cart.UserId = user.Id;

            _dbContext.Update(Cart);
            _dbContext.SaveChanges();

            Response.Redirect("/Cart/Index");
        }
    }
}
