/**
This code was generated by THE SPARKLING EVENTUAL CONSISTENT UNICORNS
Do not touch or risk the wrath of the ECUs
This Command was generated from DSL.json
*/
using Acme.Commands;
namespace Acme.Commands {public class RemoveProductFromCart: Command {public string customerId {get;}
public string cartId {get;}
public string productId {get;}public RemoveProductFromCart (string customerIdArg, string cartIdArg, string productIdArg) {customerId = customerIdArg;
cartId = cartIdArg;
productId = productIdArg;}
}}