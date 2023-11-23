using System;

class Program
{
    private static UserInput input = new UserInput();
    private static BreathingActivity activity1 = CreateBreathingActivity();
    private static ReflectingActivity activity2 = CreateReflectingActivity();
    private static ListingActivity activity3 = CreateListingActivity();

    static void Main(string[] args)
    {
        string[] options = new string[] { "breathing", "reflecting", "listing", "quit" };
        bool mustContinue = true;

        do
        {
            string choice = Menu(options);

            switch (choice)
            {
                case "1":
                    activity1.Run();
                    break;
                case "2":
                    activity2.Run();
                    break;
                case "3":
                    activity3.Run();
                    break;
                case "4":
                    mustContinue = !mustContinue;
                    break;
                default:
                    break;
            }
        } while (mustContinue);
    }

    private static string Menu(string[] options)
    {
        Console.Clear();

        Console.WriteLine("Menu Options:\n");

        for (int i = 0; i < options.Length; i++)
        {
            if (options[i].Contains("ing"))
                Console.WriteLine($"{i + 1}. Start {options[i]} activity");
            else
                Console.WriteLine($"{i + 1}. {Capitalize(options[i])}");
        }

        Console.WriteLine();

        Console.Write("Select a choice from the menu: ");
        input.Ask();

        return input.GetInputText();
    }

    private static string Capitalize(string word)
    {
        return char.ToUpper(word[0]) + word[1..];
    }

    private static BreathingActivity CreateBreathingActivity()
    {
        string name = "Breathing Activity";
        string description = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";

        return new BreathingActivity(name, description);
    }

    private static ReflectingActivity CreateReflectingActivity()
    {
        string name = "Reflecting Activity";
        string description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        List<string> prompts = new List<string> { "Think of a time when you stood up for someone else.", "Think of a time when you did something really difficult.", "Think of a time when you helped someone in need.", "Think of a time when you did something truly selfless." };
        List<string> questions = new List<string> { "Why was this experience meaningful to you?", "Have you ever done anything like this before?", "How did you get started?", "How did you feel when it was complete?", "What made this time different than other times when you were not as successful?", "What is your favorite thing about this experience?", "What could you learn from this experience that applies to other situations?", "What did you learn about yourself through this experience?", "How can you keep this experience in mind in the future?" };

        return new ReflectingActivity(name, description, prompts, questions);
    }

    private static ListingActivity CreateListingActivity()
    {
        string name = "Listing Activity";
        string description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        List<string> prompts = new List<string> { "Who are people that you appreciate?", "What are personal strengths of yours?", "Who are people that you have helped this week?", "When have you felt the Holy Ghost this month?", "Who are some of your personal heroes?" };

        return new ListingActivity(name, description, prompts);
    }
}