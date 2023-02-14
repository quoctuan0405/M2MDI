using System.ComponentModel.DataAnnotations;

namespace DemoRazorPage.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        public virtual IEnumerable<Cart> Carts { get; set; }
    }
}
