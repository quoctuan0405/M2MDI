using System.ComponentModel.DataAnnotations;

namespace DIFromScratchEnd.Model
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public String Name { get; set; }

        [Required]
        public String Manufacture { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int ReleaseYear { get; set; }

        public int Quantity { get; set; }
    }
}
