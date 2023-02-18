using DIFromScratchEnd.Data;
using DIFromScratchEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIFromScratchEnd.Page
{
    public class SummaryPage
    {
        private ApplicationDBContext _dbContext { get; set; }

        public SummaryPage(ApplicationDBContext dbContext)
        {
            _dbContext= dbContext;
        }

        public void GetSummary() 
        {
            CountUser();
            CountCar();
        }

        private void CountUser()
        {
            int userCount = 0;

            userCount = _dbContext.Users.Count();

            Console.WriteLine("Number of users: " + userCount);
        }

        private void CountCar()
        {
            int carCount = 0;

            carCount = _dbContext.Cars.Count();

            Console.WriteLine("Number of cars: " + carCount);
        }
    }
}
