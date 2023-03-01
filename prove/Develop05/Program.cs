using System;
using System.Threading;

namespace MindfulnessApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflecting Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. Quit");

            Console.Write("Select a choice from the menu: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    StartBreathingActivity();
                    break;

                case 2:
                    StartReflectingActivity();
                    break;

                case 3:
                    StartListingActivity();
                    break;

                case 4:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please select again.");
                    Main(args);
                    break;
            }
        }

        static void StartBreathingActivity()
        {
            Console.Write("Enter duration of activity in seconds: ");
            int duration = int.Parse(Console.ReadLine());

            Console.WriteLine("Breathing Activity");
            Console.WriteLine("This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");
            Console.WriteLine("Get ready to begin in 3 seconds...");

            for (int i = 3; i >= 1; i--)
            {
                Console.Write(i + "...");
                Thread.Sleep(1000);
            }

            Console.WriteLine("Begin!");

            for (int i = 0; i < duration; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine("Breathe in...");
                }
                else
                {
                    Console.WriteLine("Breathe out...");
                }

                Thread.Sleep(1000);
            }

            Console.WriteLine("Well done! You have completed the Breathing Activity for {0} seconds.", duration);
            Thread.Sleep(2000);
            Main(null);
        }

        static void StartReflectingActivity()
        {
            Console.Write("Enter duration of activity in seconds: ");
            int duration = int.Parse(Console.ReadLine());

            Console.WriteLine("Reflection Activity");
            Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
            Console.WriteLine("Get ready to begin in 3 seconds...");

            for (int i = 3; i >= 1; i--)
            {
                Console.Write(i + "...");
                Thread.Sleep(1000);
            }

            Console.WriteLine("Begin!");

            Random random = new Random();
            string[] prompts = { "Think of a time when you stood up for someone else.", "Think of a time when you did something really difficult.", "Think of a time when you helped someone in need.", "Think of a time when you did something truly selfless." };

            int count = 0;
            while (count < duration)
            {
                string prompt = prompts[random.Next(prompts.Length)];

                Console.WriteLine(prompt);

                string[] questions = {
                    "Why was this experience meaningful to you?",
                    "Have you ever done anything like this before?",
                    "How did you get started?",
                    "How did you feel when it was complete?",
                    "What made this time different than other times when you were not as successful?",
                    "What is your favorite thing about this experience?",
                    "What could you learn from this experience that applies to other situations?",
                    "What did you learn about yourself through this experience?",
                    "How can you keep this experience in mind in future situations?"
};
                string question = questions[random.Next(questions.Length)];

            Console.WriteLine(question);

            Thread.Sleep(5000);

            count += 10;
        }

        Console.WriteLine("Well done! You have completed the Reflection Activity for {0} seconds.", duration);
        Thread.Sleep(2000);
        Main(null);
    }

    static void StartListingActivity()
    {
        Console.Write("Enter duration of activity in seconds: ");
        int duration = int.Parse(Console.ReadLine());

        Console.WriteLine("Listing Activity");
        Console.WriteLine("This activity will help you organize your thoughts and clear your mind by making a list of things that are important to you. This can be anything from goals, to priorities, to things you are grateful for.");
        Console.WriteLine("Get ready to begin in 3 seconds...");

        for (int i = 3; i >= 1; i--)
        {
            Console.Write(i + "...");
            Thread.Sleep(1000);
        }

        Console.WriteLine("Begin!");

        int count = 0;
        while (count < duration)
        {
            Console.Write("Enter an item for your list: ");
            string item = Console.ReadLine();

            Console.WriteLine("Added {0} to your list.", item);

            count += 5;
        }

        Console.WriteLine("Well done! You have completed the Listing Activity for {0} seconds.", duration);
        Thread.Sleep(2000);
        Main(null);
    }
}
}
