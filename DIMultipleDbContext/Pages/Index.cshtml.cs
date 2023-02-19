using DIMultipleDbContext.Data;
using DIMultipleDbContext.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StackExchange.Redis;

namespace DIMultipleDbContext.Pages
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        private readonly PostgresDBContext _postgresDBContext;
        private readonly SqlServerDBContext _sqlServiceDBContext;
        private readonly IConnectionMultiplexer _redis;

        public List<User> Users { get; set; }
        public List<Car> Cars { get; set; }
        public List<Set> Sets { get; set; }
        public string Hi { get; set; }

        public IndexModel(PostgresDBContext postgresDBContext, SqlServerDBContext sqlServerDBContext, IConnectionMultiplexer connectionMultiplexer)
        {
            _postgresDBContext = postgresDBContext;
            _sqlServiceDBContext= sqlServerDBContext;
            _redis = connectionMultiplexer;
        }

        public void OnGet()
        {
            Users = _sqlServiceDBContext.Users.ToList();
            Cars = _sqlServiceDBContext.Cars.ToList();
            Sets = _postgresDBContext.Sets.ToList();

            var redis = _redis.GetDatabase();
            redis.StringSet("hi", "there");
            Hi = redis.StringGet("hi").ToString();
        }
    }
}