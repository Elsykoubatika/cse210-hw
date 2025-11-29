using System;
using System.Net.Sockets;

public class Customer
{
    private string _name;
    private Address _address;

    private bool _isInUSA;

    public Customer(Address address, string name)
    {
        _name = name;
        _address = address;
    }

    public string GetName()
    {
        return _name;
    }
    public string GetAddress()
    {
        return _address.GetAddress();
    }
    public bool GetCountry()
    {   
        string country = _address.GetCountry();
        if (country == "USA")
        {
            _isInUSA = true;
        }
        else
        {
            _isInUSA = false;
        }
        return _isInUSA;
    }
}