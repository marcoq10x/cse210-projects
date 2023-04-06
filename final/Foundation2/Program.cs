using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Product product1 = new Product("Keyboard", 1, 29.99, 1);
        Product product2 = new Product("Mouse", 2, 19.99, 1);
        Address address1 = new Address("502 Main St", "New York", "NY", "USA");
        Customer customer1 = new Customer("John Denver", address1);
        List<Product> products1 = new List<Product> { product1, product2 };
        Order order1 = new Order(products1, customer1);

        Product product3 = new Product("Monitor", 3, 199.99, 1);
        Product product4 = new Product("Speaker", 4, 49.99, 2);
        Address address2 = new Address("753 High St", "London", "England", "UK");
        Customer customer2 = new Customer("Jane Smith", address2);
        List<Product> products2 = new List<Product> { product3, product4 };
        Order order2 = new Order(products2, customer2);

        Console.WriteLine("Order 1:");
        Console.WriteLine("Packing Label:\n" + order1.PackingLabel());
        Console.WriteLine("Shipping Label:\n" + order1.ShippingLabel());
        Console.WriteLine("Total Price: $" + order1.CalculateTotalCost());
        Console.WriteLine();

        Console.WriteLine("Order 2:");
        Console.WriteLine("Packing Label:\n" + order2.PackingLabel());
        Console.WriteLine("Shipping Label:\n" + order2.ShippingLabel());
        Console.WriteLine("Total Price: $" + order2.CalculateTotalCost());
    }
}

class Product
{
    private string _productName;
    private int _productID;
    private double _price;
    private int _quantity;

    public Product(string productName, int productID, double price, int quantity)
    {
        _productName = productName;
        _productID = productID;
        _price = price;
        _quantity = quantity;
    }

    public double GetTotalPrice() => _price * _quantity;
    public string GetName() => _productName;
    public int GetProductID() => _productID;
}

class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public bool IsInUSA() => _address.IsInUSA();
    public string GetName() => _name;
    public Address GetAddress() => _address;
}

class Address
{
    private string _street;
    private string _city;
    private string _state;
    private string _country;

    public Address(string street, string city, string state, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
    }

    public bool IsInUSA() => _country == "USA";
    public override string ToString() => $"{_street}\n{_city}, {_state}\n{_country}";
}

class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(List<Product> products, Customer customer)
    {
        _products = products;
        _customer = customer;
    }

    public double CalculateTotalCost()
    {
        double total = _customer.IsInUSA() ? 5 : 35;
        foreach (Product product in _products)
        {
            total += product.GetTotalPrice();
        }
        return total;
    }

    public string PackingLabel()
    {
        string label = "";
        foreach (Product product in _products)
        {
            label += $"{product.GetName()} (ID: {product.GetProductID()})\n";
        }
        return label;
    }

    public string ShippingLabel() => $"{_customer.GetName()}\n{_customer.GetAddress()}";
}

