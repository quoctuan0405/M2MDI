namespace DIMultipleDbContext.Model
{
    public class Cart
    {
        public int Id { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int Quantity { get; set; }
    }
}
