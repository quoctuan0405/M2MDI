using DIFromScratchStart.Data;
using DIFromScratchStart.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIFromScratchStart.Page
{
    public class SummaryPage
    {
        public void GetSummary() 
        {
            CountUser();
            CountCar();
        }

        private void CountUser()
        {
            using (ApplicationDBContext dbContext = new ApplicationDBContext())
            {
                int userCount = 0;

                userCount = dbContext.Users.Count();

                Console.WriteLine("Number of users: " + userCount);
            }

        }

        private void CountCar()
        {
            using (ApplicationDBContext dbContext = new ApplicationDBContext())
            {
                int carCount = 0;

                carCount = dbContext.Cars.Count();

                Console.WriteLine("Number of cars: " + carCount);
            }
        }
    }
}
