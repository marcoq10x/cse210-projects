using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    private static int _input;

    static void Main(string[]args)
    {
        Console.WriteLine("--Welcome to the Mind Spa--");
        Console.WriteLine("Menu Options:");
        Console.WriteLine("1. Start Breathing Activity");
        Console.WriteLine("2. Start Reflecting Activity");
        Console.WriteLine("3. Start Listing Activity");
        Console.WriteLine("4. Start Stretching Activity");
        Console.WriteLine("5. Quit");
        Console.WriteLine("Select a choice from the menu: ");

        _input = int.Parse(Console.ReadLine());

        switch (_input)
        {
            case 1:
                Console.Write("Enter duration (in seconds): ");
                int _duration = int.Parse(Console.ReadLine());
                Console.WriteLine("This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.");
                BreathingActivity breathingActivity = new BreathingActivity(_duration);
                breathingActivity.RunActivity();
                break;

            case 2:
                Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
                Console.Write("Enter duration (in seconds): ");
                _duration = int.Parse(Console.ReadLine());
                ReflectingActivity reflectingActivity = new ReflectingActivity();
                reflectingActivity.RunActivity();
                break;
            
            case 3:
                Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
                Console.Write("Enter duration (in seconds): ");
                _duration = int.Parse(Console.ReadLine());
                ListingActivity listingActivity = new ListingActivity();
                listingActivity.RunActivity();
                break;

            case 4:
                Console.WriteLine("This activity will help you stretch your muscles and increase your flexibility. Make sure to breathe deeply and stay relaxed throughout the activity.");
                Console.Write("Enter duration (in seconds): ");
                int _stretchingDuration = int.Parse(Console.ReadLine());
                StretchingActivity stretchingActivity = new StretchingActivity();
                stretchingActivity.RunActivity();
                break;

            case 5:
                Environment.Exit(0);
                break;

            default:
                Console.WriteLine("Invalid input. Please try again.");

                break;
        }
    }
}

internal class StretchingActivity
{
    internal void RunActivity()
    {
        throw new NotImplementedException();
    }
}

public class Activity
{
    protected string _startMessage;
    protected string _endMessage;
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity()
    {
        _startMessage = "Get ready to start in...";
        _endMessage = "Good job! You have completed the Activity.";
        _name = "";
        _description = "";
        _duration = 10;
    }

    public void GetSpinner()
    {
        List<string> animationStrings = new List<string>();

        animationStrings.Add("|");
        animationStrings.Add("/");
        animationStrings.Add("-");
        animationStrings.Add("\\");
        animationStrings.Add("|");
        animationStrings.Add("/");
        animationStrings.Add("-");
        animationStrings.Add("\\");

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(5);
        while (DateTime.Now < endTime)
        {
            foreach (string s in animationStrings)
            {
                Console.Write(s);
                Thread.Sleep(500);
                Console.Write("\b \b");
            }
        }
    }

    public virtual void GetTimer(int _duration)
    {

        for (int i = _duration; i > 0; i--)
        {
            Console.Write("\r{0} seconds remaining ", i);
            

            System.Threading.Thread.Sleep(1000);
        }
       
        GetSpinner();
    }

    public virtual void RunActivity()
    {
        Console.WriteLine(_startMessage);
        GetSpinner();
        GetTimer(_duration);
        
         Console.WriteLine("\nTimer ended.");
        Console.WriteLine(_endMessage);
    }

    public int GetDuration()
    {
        return _duration;
        
    }
}

public class BreathingActivity : Activity
{
    public BreathingActivity(int _duration) : base ()
    {
    }
    private string _breathIn;
    private string _breathOut;

    public BreathingActivity()
    {
        _name = "Breathing";
        _description = "Deep breathing exercise to promote relaxation.";
        _duration = 0;
        _breathIn = "Inhale deep...";
        _breathOut = "Exhale slow...";
    }

    public override void RunActivity()
    {
        Console.WriteLine(_startMessage);
        GetSpinner();
        for (int i = 3; i >= 1; i--)
        {
            Console.WriteLine(i);
            System.Threading.Thread.Sleep(1000);
            
        }
        Console.WriteLine("Start!");
        Console.WriteLine(_breathIn);
        GetTimer(_duration);
        Console.WriteLine(_breathOut);
        GetTimer(_duration);
        Console.WriteLine(_endMessage);
    }
}

class ReflectingActivity : Activity
{
    private string _prompt;
    private string _question;
    private string[] _reflectPrompts;

    public ReflectingActivity()
    {
        _name = "Self-reflection";
        _description = "Reflection activity to promote self-awareness.";
        _duration = 10;
        _prompt = "Think about a time when you did something really difficult?";
        _question = "How does this experience relate to your current state of mind?";
        _reflectPrompts = new string[] { "What is your biggest fear?", "What is your greatest strength?" };
        }

    public override void RunActivity()
    {
        Console.WriteLine(_startMessage);
        GetSpinner();
          for (int i = 3; i >= 1; i--)
        {
            Console.WriteLine(i);
            System.Threading.Thread.Sleep(1000);
            
        }
        Console.WriteLine("Start!");
        Console.WriteLine(_prompt);
        GetSpinner();
        System.Threading.Thread.Sleep(_duration); 
        Console.WriteLine(_question);
        GetSpinner();
        System.Threading.Thread.Sleep(_duration); 
        Console.WriteLine("Here are some additional prompts for further reflection:");
        foreach (string prompt in _reflectPrompts)
        {
            Console.WriteLine("- " + prompt);
        }
        GetTimer(_duration);
        GetSpinner();
        Console.WriteLine(_endMessage);
    }

    public void Display()
    {
        Console.WriteLine("Self-reflection Instructions:");
        Console.WriteLine(_prompt);
        Console.WriteLine(_question);
        Console.WriteLine("Additional prompts:");
        foreach (string prompt in _reflectPrompts)
        {
            Console.WriteLine("- " + prompt);
        }
    }
}


class ListingActivity : Activity
{
private string[] _tasks;

public ListingActivity()
{
    _name = "Listing Tasks";
    _description = "Activity to organize tasks and promote productivity.";
    _duration = 10;
    _tasks = new string[] { };
}

public override void RunActivity()
{
    Console.WriteLine(_startMessage);
    GetSpinner();
    GetRandomPrompt();
    
    for (int i = 3; i >= 1; i--)
        {
            Console.WriteLine(i);
            System.Threading.Thread.Sleep(1000);
            
        }
        Console.WriteLine("Start!");
        DisplayRandomPrompt();
    Console.WriteLine("Enter a task (or enter 'done' to finish):");
    string task = Console.ReadLine();
    while (task != "done")
    {
        Array.Resize(ref _tasks, _tasks.Length + 1);
        _tasks[_tasks.Length - 1] = task;
        Console.WriteLine("Enter a task (or enter 'done' to finish):");
        task = Console.ReadLine();
    }
    Console.WriteLine("Here are your tasks:");
    for (int i = 0; i < _tasks.Length; i++)
    {
        Console.WriteLine((i + 1) + ". " + _tasks[i]);
    }
    GetTimer(_duration);
    GetSpinner();
    Console.WriteLine(_endMessage);
}
 public string GetRandomPrompt()
    {
        List<string> prompts = new List<string>()
        {
            "When have you felt the Holy Ghost this month?",
            "Who are people that you appreciate?",
            "Who are some of your personal heroes?"
        };
        Random random = new Random();
        int index = random.Next(prompts.Count);
        return prompts[index];
        }
public void DisplayRandomPrompt()
{
    string randPrompt = GetRandomPrompt();
    Console.WriteLine(randPrompt);
    
}

public class StretchingActivity : Activity
{
    public StretchingActivity(int duration)
    {
        _name = "Stretching Activity";
        _description = "This activity will help you stretch your muscles and increase your flexibility. Make sure to breathe deeply and stay relaxed throughout the activity.";
        _duration = duration;
    }

    public override void RunActivity()
    {
        
        Console.WriteLine(_name);
        Console.WriteLine(_description);
        Console.WriteLine(_startMessage);
        GetSpinner();
        Console.WriteLine("\n");

        Console.WriteLine("Starting the activity now...");

        GetTimer(_duration);

        Console.WriteLine("\n");
        Console.WriteLine(_endMessage);
        Console.WriteLine("Press any key to return to the main menu.");
        Console.ReadKey();
    }
}

}

//has extra activity
   