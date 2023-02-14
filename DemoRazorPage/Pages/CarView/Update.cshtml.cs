using DemoRazorPage.Data;
using DemoRazorPage.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoRazorPage.Pages.CarView
{
    [BindProperties]
    public class UpdateModel : PageModel
    {
       
        private readonly ApplicationDBContext _db;
        public Car Car { get; set; }
        public UpdateModel(ApplicationDBContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
           Car = _db.Cars.FirstOrDefault(x=>x.Id == id); 
        }
        public void OnPost()
        {
             _db.Update(Car);
            _db.SaveChanges();

            Response.Redirect("CarIndex");
        }
    }
}
