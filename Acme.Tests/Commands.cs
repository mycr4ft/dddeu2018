namespace Acme.Messages.Commands
{
    public class StartShopping
    {
        public string customerId { get; set; }
        public int cartId { get; set; }
    }
    public class AddProductToCart
    {
        public string customerId { get; set; }
        public int cartId { get; set; }
    }
    public class RemoveProductFromCart
    {
        public string customerId { get; set; }
        public int cartId { get; set; }
    }
    public class PlaceOrder
    {
        public string customerId { get; set; }
        public int cartId { get; set; }
    }
    public class AbandonOrder
    {
        public string customerId { get; set; }
        public int cartId { get; set; }
    }
}
