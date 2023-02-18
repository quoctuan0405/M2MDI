using DIFromScratchStart.Data;
using DIFromScratchStart.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIFromScratchStart.Page
{
    public class UserPage
    {
        public void All()
        {
            using (ApplicationDBContext dbContext = new ApplicationDBContext())
            {
                List<User> users = dbContext.Users.ToList();

                foreach (var user in users)
                {
                    Console.WriteLine(user.Id + ": " + user.Username);
                }
            }
        }
    }
}
