using DemoRazorPage.Data;
using DemoRazorPage.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoRazorPage.Pages.Cart
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDBContext _dbContext;

        public DeleteModel(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void OnGet(int id)
        {
            var cart = _dbContext.Carts.Find(id);
            if (cart != null)
            {
                _dbContext.Carts.Remove(cart);
                _dbContext.SaveChanges();

            }
            Response.Redirect("/Cart/Index");
        }
    }
}
