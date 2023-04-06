using System;

class Program
{
    static void Main(string[] args)
    {
        Lecture lecture = new Lecture("Machine Learning 101", "An introduction to machine learning concepts.", new DateTime(2023, 5, 20), new DateTime(2023, 5, 20, 10, 0, 0), new Address("123 Main St", "New York", "NY", "USA", "10001"), "Dr. John Doe", 100);
        Reception reception = new Reception("Tech Networking Event", "A networking event for professionals in the tech industry.", new DateTime(2023, 6, 15), new DateTime(2023, 6, 15, 18, 30, 0), new Address("789 Broadway", "San Francisco", "CA", "USA", "94103"), "rsvp@tech-networking.com");
        OutdoorGathering gathering = new OutdoorGathering("City Park Picnic", "A casual gathering for friends and family at the city park.", new DateTime(2023, 7, 4), new DateTime(2023, 7, 4, 12, 0, 0), new Address("456 Park Ave", "Los Angeles", "CA", "USA", "90001"), "Sunny with a chance of clouds.");

        // Output marketing messages for each event
        Console.WriteLine("Lecture:");
        Console.WriteLine(lecture.StandardDetails());
        Console.WriteLine(lecture.FullDetails());
        Console.WriteLine(lecture.ShortDescription());
        Console.WriteLine();

        Console.WriteLine("Reception:");
        Console.WriteLine(reception.StandardDetails());
        Console.WriteLine(reception.FullDetails());
        Console.WriteLine(reception.ShortDescription());
        Console.WriteLine();

        Console.WriteLine("Outdoor Gathering:");
        Console.WriteLine(gathering.StandardDetails());
        Console.WriteLine(gathering.FullDetails());
        Console.WriteLine(gathering.ShortDescription());
        Console.WriteLine();
    }
}

public class Address
{
    private string _street;
    private string _city;
    private string _state;
    private string _country;
    private string _postalCode;

    public Address(string street, string city, string state, string country, string postalCode)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
        _postalCode = postalCode;
    }

    public override string ToString()
    {
        return $"{_street}, {_city}, {_state}, {_country}, {_postalCode}";
    }
}

public abstract class Event
{
    protected string _eventTitle;
    protected string _description;
    protected DateTime _date;
    protected DateTime _time;
    protected Address _address;

    public Event(string eventTitle, string description, DateTime date, DateTime time, Address address)
    {
        _eventTitle = eventTitle;
        _description = description;
        _date = date;
        _time = time;
        _address = address;
    }

    public abstract string StandardDetails();

    public abstract string FullDetails();

    public abstract string ShortDescription();
}

public class Lecture : Event
{
    private string _speaker;
    private int _capacity;

    public Lecture(string eventTitle, string description, DateTime date, DateTime time, Address address, string speaker, int capacity)
        : base(eventTitle, description, date, time, address)
    {
        _speaker = speaker;
        _capacity = capacity;
    }

        public override string StandardDetails()
    {
        return $"{_eventTitle}\n{_description}\n{_date.ToShortDateString()} {_time.ToShortTimeString()}\n{_address}";
    }

    public override string FullDetails()
    {
        return $"{StandardDetails()}\nLecture by {_speaker}\nCapacity: {_capacity}";
    }

    public override string ShortDescription()
    {
        return $"Lecture: {_eventTitle} on {_date.ToShortDateString()}";
    }
}

public class Reception : Event
{
    private string _rsvpEmail;

    public Reception(string eventTitle, string description, DateTime date, DateTime time, Address address, string rsvpEmail)
        : base(eventTitle, description, date, time, address)
    {
        _rsvpEmail = rsvpEmail;
    }

    public override string StandardDetails()
    {
        return $"{_eventTitle}\n{_description}\n{_date.ToShortDateString()} {_time.ToShortTimeString()}\n{_address}";
    }

    public override string FullDetails()
    {
        return $"{StandardDetails()}\nRSVP to {_rsvpEmail}";
    }

    public override string ShortDescription()
    {
        return $"Reception: {_eventTitle} on {_date.ToShortDateString()}";
    }
}

public class OutdoorGathering : Event
{
    private string _weather;

    public OutdoorGathering(string eventTitle, string description, DateTime date, DateTime time, Address address, string weather)
        : base(eventTitle, description, date, time, address)
    {
        _weather = weather;
    }

    public override string StandardDetails()
    {
        return $"{_eventTitle}\n{_description}\n{_date.ToShortDateString()} {_time.ToShortTimeString()}\n{_address}";
    }

    public override string FullDetails()
    {
        return $"{StandardDetails()}\nWeather: {_weather}";
    }

    public override string ShortDescription()
    {
        return $"Outdoor Gathering: {_eventTitle} on {_date.ToShortDateString()}";
    }
}

