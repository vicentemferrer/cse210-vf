using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> userNumberList = new List<int>();
        string userInput;
        int sum = 0, largest = 0, smallest = 100;
        double average = 0;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        do
        {
            Console.Write("Enter number: ");
            userInput = Console.ReadLine().Trim();

            userNumberList.Add(int.Parse(userInput));
        } while (userNumberList.Last() != 0);

        userNumberList.Remove(0);

        foreach (int number in userNumberList)
        {
            sum += number;
            largest = Math.Max(largest, number);
            smallest = number > 0 ? Math.Min(smallest, number) : smallest;
        }

        average = (double)sum / userNumberList.Count;

        userNumberList.Sort();

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");
        Console.WriteLine($"The smallest positive number is: {smallest}");

        Console.WriteLine("The sorted list is:");
        foreach (int number in userNumberList)
            Console.WriteLine(number);
    }
}