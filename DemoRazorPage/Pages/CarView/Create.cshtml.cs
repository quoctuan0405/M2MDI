using DemoRazorPage.Data;
using DemoRazorPage.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoRazorPage.Pages.CarView
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDBContext _db;

        public CreateModel(ApplicationDBContext db)
        {
            _db = db;
        }

         
        public Car Car { get; set; }

        public void OnGet()
        {
           
        }
        
        public void OnPost()
        {
             _db.Add(Car);
             _db.SaveChanges();


            Response.Redirect("CarIndex");
        }
    }
}
