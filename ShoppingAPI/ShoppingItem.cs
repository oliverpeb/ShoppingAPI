namespace ShoppingAPI
{
    public class shoppingitem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public shoppingitem()
        {

        }

        public shoppingitem(int id, string name, double price, int quantity)
        {
            Id = id;
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Price: {Price}, Quantity: {Quantity}";
        }

        public void Validate()
        {

        }

    }
}