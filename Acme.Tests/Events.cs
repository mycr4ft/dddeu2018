namespace Acme.Messages.Events {
public class CustomerStartedShopping {
public string customerId {get;set;}
public int cartId {get;set;}
}
public class ProductWasAddedToCart {
public string customerId {get;set;}
public int cartId {get;set;}
}
public class ProductWasRemovedFromCart {
public string customerId {get;set;}
public int cartId {get;set;}
}
public class CustomerPlacedOrder {
public string customerId {get;set;}
public int cartId {get;set;}
}
public class CustomerAbandonedCart {
public string customerId {get;set;}
public int cartId {get;set;}
}
}
