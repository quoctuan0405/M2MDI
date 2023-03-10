using System.ComponentModel.DataAnnotations;

namespace DIFromScratchStart.Model
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
