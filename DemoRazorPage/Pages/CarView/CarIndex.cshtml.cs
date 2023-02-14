using DemoRazorPage.Data;
using DemoRazorPage.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DemoRazorPage.Pages.CarView
{
    [BindProperties]
    public class CarIndexModel : PageModel
    {
        private readonly ApplicationDBContext _dbContext;
        public Car Car { get; set; }
        public IEnumerable<Car> cars { get; set; }
        public CarIndexModel(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void OnGet()
        {
            cars = _dbContext.Cars;
        }

        public void OnPost()
        {
            if (Car.Name == null)
            {
                cars = _dbContext.Cars;
            }
            else
            {
               cars = from c in _dbContext.Cars
                        where c.Name.Contains(Car.Name) 
                        select c;
            }

        }
    }
}
