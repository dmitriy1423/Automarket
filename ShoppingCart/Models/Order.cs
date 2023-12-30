﻿namespace ShoppingCart.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public DateTime OrderDate { get; set; }

        public double TotalPrice { get; set; }

        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public int MarkerId { get; set; }

        public Marker Marker { get; set; }
    }
}
