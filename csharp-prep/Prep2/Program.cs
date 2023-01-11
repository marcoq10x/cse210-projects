using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask the user for their grade percentage
        Console.WriteLine("Please enter your grade percentage: ");
        int grade = int.Parse(Console.ReadLine());

        // Determine the letter grade
        string letter = "";
        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Determine the sign of the grade
        string sign = "";
        if (grade % 10 >= 7 && letter != "A")
        {
            sign = "+";
        }
        else if (grade % 10 < 3 && letter != "F")
        {
            sign = "-";
        }

        // Handle the exceptional cases of A+ and F-
        if (letter == "A" && sign == "+")
        {
            sign = "";
        }
        else if (letter == "F" && sign == "-")
        {
            sign = "";
        }

        // Print the grade letter and sign
        Console.WriteLine($"{letter}{sign}");

        // Determine if the user passed the course
        if (grade >= 70)
        {
            Console.WriteLine("Congratulations, you passed the class. Now let's go party!");
        }
        else
        {
            Console.WriteLine("Sorry, better luck next time!");
        }
    }
}