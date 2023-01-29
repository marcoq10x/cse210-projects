using System;
using System.IO;
using System.Collections.Generic;

/*First Class "program" */
class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();

        while (true)
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Load the journal from a file");
            Console.WriteLine("4. Save the journal to a file");
            Console.WriteLine("5. Exit");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    journal.WriteEntry();
                    break;
                case 2:
                    journal.DisplayEntries();
                    break;
                case 3:
                    Console.Write("Enter the filename: ");
                    string filename = Console.ReadLine();
                    journal.LoadFromFile(filename);
                    break;
                case 4:
                    Console.Write("Enter the filename: ");
                    filename = Console.ReadLine();
                    journal.SaveToFile(filename);
                    break;
                case 5:
                    return;
            }
        }
    }
}

/* Second Class "Entry" */
class Entry
{
    public string prompt;
    public string response;
    public DateTime date;

    public Entry(string prompt, string response)
    {
        this.prompt = prompt;
        this.response = response;
        this.date = DateTime.Now;
    }
}

/* Third class "Journal" */
class Journal
{
    /*this part of code i will encapsulate(make private) so that it doesn't affect in other parts of the code nor can be manipulated (week 5 lesson)*/
    public void SaveToFile(string filename)
{
    using (StreamWriter writer = new StreamWriter(filename))
    {
        foreach (Entry entry in entries)
        {
            string line = entry.date + "," + entry.prompt + "," + entry.response;
            writer.WriteLine(line);
        }
    }
}
    private List<Entry> entries = new List<Entry>();
    private List<string> prompts = new List<string>() {
        "What scripture did I read today?",
        "What changes can I make to become a better person?",
        "Did I do something good for someone else?",
        "Did I compliment my wife today?",
        "What is my goal for tomorrow?"
    };

    public void WriteEntry()
    {
        Random rand = new Random();
        int index = rand.Next(prompts.Count);
        string prompt = prompts[index];

        Console.Write(prompt + " ");
        string response = Console.ReadLine();

        Entry entry = new Entry(prompt, response);
        entries.Add(entry);
    }

    public void DisplayEntries()
    {
        foreach (Entry entry in entries)
        {
            Console.WriteLine("Date: " + entry.date);
            Console.WriteLine("Prompt: " + entry.prompt);
            Console.WriteLine("Response: " + entry.response);
            Console.WriteLine();
        }
    }

    public void LoadFromFile(string filename)
    {
        entries.Clear();

        using (StreamReader reader = new StreamReader(filename))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] parts = line.Split(',');

                DateTime date = DateTime.Parse(parts[0]);
                string prompt = parts[1];
                string response = parts[2];

                Entry entry = new Entry(prompt, response);
                entries.Add(entry);
            }
        }    
    }
}