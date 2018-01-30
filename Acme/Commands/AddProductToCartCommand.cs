/**
This code was generated by THE SPARKLING EVENTUAL CONSISTENT UNICORNS
Do not touch or risk the wrath of the ECUs
This Command was generated from DSL.json
*/

using Acme.Commands;

namespace Acme.Commands
{
    public class AddProductToCart : Command
    {
        public string customerId { get; }
        public string cartId { get; }
        public string sku { get; }
        public string addTime { get; }

        public AddProductToCart(string customerIdArg, string cartIdArg, string skuArg, string addTimeArg)
        {
            customerId = customerIdArg;
            cartId = cartIdArg;
            sku = skuArg;
            addTime = addTimeArg;
        }
    }
}