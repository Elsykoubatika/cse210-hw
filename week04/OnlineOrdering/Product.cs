using System;
using System.IO.Pipes;

public class Product
{
    private string _ProductName;
    private int _productId;
    private int _price;
    private int _quantity;
    public Product(string name, int productId, int price, int quantity)
    {
        _ProductName = name;
        _productId =productId;
        _price = price;
        _quantity = quantity;
    }
    public string GetProductName()
    {
        return _ProductName;
    }
    public int GetProductId()
    {
        return _productId;
    }
    public int GetPrice()
    {
        return _price;
    }
    public int GetQuantity()
    {
        return _quantity;
    }
    public double TotalCost()
    {
        return _price * _quantity;
    }
}