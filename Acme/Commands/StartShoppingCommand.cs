/**
This code was generated by THE SPARKLING EVENTUAL CONSISTENT UNICORNS
Do not touch or risk the wrath of the ECUs
This Command was generated from DSL.json
*/
using Acme.Commands;
namespace Acme.Commands {public class StartShopping: Command {public string customerId {get;}
public string cartId {get;}
public string startTime {get;}public StartShopping (string customerIdArg, string cartIdArg, string startTimeArg) {customerId = customerIdArg;
cartId = cartIdArg;
startTime = startTimeArg;}
}}