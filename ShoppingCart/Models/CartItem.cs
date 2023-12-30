namespace ShoppingCart.Models
{
    public class CartItem
    {
        public int Id { get; set; }

        public int CarId { get; set; }

        public string CarName { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public double Total { get { return Quantity * Price; } }

        public string Image { get; set; }

        public CartItem()
        {

        }

        public CartItem(Car car)
        {
            CarId = car.Id;
            CarName = car.Name;
            Price = car.Price;
            Quantity = 1;
            Image = car.Image;
        }
    }
}
