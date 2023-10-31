using System;

class Program
{
    static void Main(string[] args)
    {
        Random magicNumberBox = new Random();
        string userInput, wannaPlay = "n";
        int guess;

        do
        {
            int magicNumber = magicNumberBox.Next(1, 100), guessesMade = 0;

            Console.WriteLine("What is the magic number?");

            do
            {
                Console.Write("What is your guess? ");
                userInput = Console.ReadLine().Trim();

                guess = int.Parse(userInput);

                Console.WriteLine(guess == magicNumber ? "You guessed it!" : guess < magicNumber ? "Higher" : "Lower");

                guessesMade++;
            } while (guess != magicNumber);

            Console.WriteLine($"Guesses made: {guessesMade}");

            Console.Write("Wanna play again? (y/n) ");
            wannaPlay = Console.ReadLine().Trim();
        } while (wannaPlay.ToLower() == "y" || wannaPlay.ToLower() == "yes");
    }
}