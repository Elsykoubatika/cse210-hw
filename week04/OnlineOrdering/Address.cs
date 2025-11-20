using System;
using System.Collections.Concurrent;
using System.Diagnostics.Contracts;
using System.Dynamic;

public class Address
{
    private string _streetAddress;
    private string _city;
    private string _state;
    private string _country;

    public Address(string street, string city, string state, string country)
    {
        _streetAddress = street;
        _city = city;
        _state = state;
        _country = country;
    }
    public string Getstreet()
    {
        return _streetAddress;
    }
    public string GetCity()
    {
        return _city;
    }

    public string GetState()
    {
        return _state;
    }

    public string GetCountry()
    {
        return _country ;
    }
    public string GetAddress()
    {
        return $"Address: {_streetAddress},{_city}, {_state}, {_country}";
    }
}