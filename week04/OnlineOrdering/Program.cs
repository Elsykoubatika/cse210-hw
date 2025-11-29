using System;
using System.ComponentModel;

class Program
{
    static void Main(string[] args)
    {
        Address address= new Address("34 matsanga St", "Anytown", "york", "USA");
        Address address2= new Address("56 king St", "Othertown", "ontario", "Canada");

        Customer customer = new Customer(address, "John Doe");
        Customer customer2 = new Customer(address2, "Jane Smith");
        Order order = new Order(customer);

        order.AddProduct(new Product("Laptop", 551, 100, 2));
        order.AddProduct(new Product("Mouse", 552, 20, 1));
        order.AddProduct(new Product("Keyboard", 553, 30, 3));

        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("Tablet", 654, 200, 1));
        order2.AddProduct(new Product("Charger", 655, 25, 2));

        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());

        Console.WriteLine($"Tatol Price = {order.TatolPrice()}");
    }
}