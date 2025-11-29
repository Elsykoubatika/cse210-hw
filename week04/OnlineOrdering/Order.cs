using System;
using System.Collections.Generic;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {   
        _products = new List<Product>();
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }
    public double TatolPrice()
    {
        double tatolCost = 0;
        int shippingCost = 0;
        foreach(Product product in _products)
        {
            tatolCost += product.TotalCost();
        }
        if (!_customer.GetCountry())
        {
            Console.WriteLine("The shipping cost is $35");
            shippingCost = 35;
        }
        else
        {
            Console.WriteLine("The shipping cost is $5");
            shippingCost = 5;
        }
        tatolCost += shippingCost;

        return tatolCost;
    }

    public string GetPackingLabel()
    {
        string label = "";
        foreach (Product product in _products)
        {
            label += $"{product.GetProductName()} (ID: {product.GetProductId()}) ${product.GetPrice()}\n";
        }
        return label;
    }
    public string GetShippingLabel()
    {
        string Shipping = "";
        foreach (Product product in _products)
        {
            Shipping += $"Shipping Label:\nName: {_customer.GetName()}\nAddress: {_customer.GetAddress()}\n";
        }
        return Shipping;
    }
}