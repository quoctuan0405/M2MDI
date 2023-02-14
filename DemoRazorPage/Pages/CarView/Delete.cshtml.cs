using DemoRazorPage.Data;
using DemoRazorPage.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoRazorPage.Pages.CarView
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDBContext _dbContext;
        public DeleteModel(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public  void  OnGet(int id)
        {
            var carFromDb = _dbContext.Cars.Find(id);
            if (carFromDb!=null)
            {
                _dbContext.Cars.Remove(carFromDb);
                _dbContext.SaveChanges();
            }

            Response.Redirect("CarIndex");
        }
    }
}
