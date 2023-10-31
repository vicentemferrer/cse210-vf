using System;

class Program
{
    static void Main(string[] args)
    {
        string userInput, letter = "";
        int userPercentage, lastDigit;

        Console.Write("What is your grade percentage? ");
        userInput = Console.ReadLine();

        userPercentage = int.Parse(userInput.Trim());
        lastDigit = userPercentage % 10;

        if (userPercentage >= 90)
            letter += "A";

        else if (userPercentage >= 80)
            letter += "B";

        else if (userPercentage >= 70)
            letter += "C";

        else if (userPercentage >= 60)
            letter += "D";

        else
            letter += "F";


        if (lastDigit >= 7 && (letter != "A" || letter != "F"))
            letter += "+";

        else if (lastDigit < 3 && letter != "F")
            letter += "-";

        Console.WriteLine($"Your grade is: {letter}");

        Console.WriteLine(userPercentage >= 70 ? "You passed!" : "Better luck next time!");
    }
}