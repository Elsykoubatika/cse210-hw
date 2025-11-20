using System;
using System.ComponentModel;

class Program
{
    static void Main(string[] args)
    {
        Address address= new Address("34 matsanga St", "Anytown", "york", "USA");
        Customer customer = new Customer(address, "John Doe");
        Order order = new Order(customer);

        order.AddProduct(new Product("Laptop", 551, 100, 2));
        order.AddProduct(new Product("Mouse", 552, 20, 1));
        order.AddProduct(new Product("Keyboard", 553, 30, 3));



        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());

        Console.WriteLine($"Tatol Price = {order.TatolPrice()}");
    }
}