using DIFromScratchEnd.Data;
using DIFromScratchEnd.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIFromScratchEnd.Page
{
    public class UserPage
    {
        private ApplicationDBContext _dbContext;

        public UserPage(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public void All()
        {
            List<User> users = _dbContext.Users.ToList();

            foreach (var user in users)
            {
                Console.WriteLine(user.Id + ": " + user.Username);
            }
        }
    }
}
