/**
This code was generated by THE SPARKLING EVENTUAL CONSISTENT UNICORNS
Do not touch or risk the wrath of the ECUs
This Event was generated from DSL.json
*/
using Acme.Events;
namespace Acme.Events {public class ProductWasAddedToCart: Event {public string customerId {get;}
public string cartId {get;}
public string productId {get;}public ProductWasAddedToCart (string customerIdArg, string cartIdArg, string productIdArg) {customerId = customerIdArg;
cartId = cartIdArg;
productId = productIdArg;}
}}