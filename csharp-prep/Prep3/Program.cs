using System;

class MainClass {
  public static void Main (string[] args) 
  {
    //part 1 & part 2
    //Console.WriteLine("What is the magic number? ");
    //int magicNumber = int.Parse(Console.ReadLine());

    //Part 3
    Random randomGenerator = new Random();
    int magicNumber = randomGenerator.Next(1, 101);
    int guess;
    int guessCount = 0;
    do {
        Console.WriteLine("What is your guess? ");
        guess = int.Parse(Console.ReadLine());
        guessCount++;
        if (guess < magicNumber) {
            Console.WriteLine("Higher");
        }
        else if (guess > magicNumber) {
            Console.WriteLine("Lower");
        }
        else {
            Console.WriteLine("You guessed it! Your number of guesses is: " + guessCount);
        }
    } while (guess != magicNumber);
  }
}
