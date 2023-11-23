public class ReflectingActivity : Activity
{
  private List<string> _prompts;
  private List<string> _questions;
  private Random _democracy = new Random();

  public ReflectingActivity(string name, string description, List<string> prompts, List<string> questions) : base(name, description)
  {
    _prompts = prompts;
    _questions = questions;
  }

  public void Run()
  {
    DisplayStartingMessage();

    DisplayPrompt();

    Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
    Console.Write("You may begin in: ");
    ShowCountDown(5);

    Console.Clear();

    DateTime startTime = DateTime.Now;
    DateTime timeToEnd = startTime.AddSeconds(_duration);
    DateTime currentTime;

    do
    {
      DisplayQuestion();

      currentTime = DateTime.Now;
    } while (currentTime < timeToEnd);

    DisplayEndingMessage();
  }

  private string GetRandomPrompt()
  {
    return _prompts[_democracy.Next(_prompts.Count)];
  }

  private string GetRandomQuestion()
  {
    return _questions[_democracy.Next(_questions.Count)];
  }

  private void DisplayPrompt()
  {
    Console.WriteLine("\nConsider the following prompt:\n");
    Console.WriteLine($" --- {GetRandomPrompt()} --- ");
    Console.Write("\nWhen you have something in mind, press enter to continue. ");
    _input.Ask();

    Console.WriteLine();
  }

  private void DisplayQuestion()
  {
    Console.Write($"> {GetRandomQuestion()} ");
    ShowSpinner(8);
  }
}