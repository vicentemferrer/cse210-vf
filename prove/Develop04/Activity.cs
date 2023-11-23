public class Activity
{
  private string _name;
  private string _description;
  private char[] _spinner = new char[] { '|', '/', '-', '\\', '|', '/', '-', '\\' };
  protected UserInput _input = new UserInput();
  protected int _duration { get; private set; }

  public Activity(string name, string description)
  {
    _name = name;
    _description = description;
  }

  private void Ask()
  {
    Console.Write("How long, in seconds, would you like for your session? ");
    _input.Ask();
    _duration = _input.GetInputValue();
  }

  public void DisplayStartingMessage()
  {
    Console.Clear();
    Console.WriteLine($"Welcome to {_name}.\n");
    Console.WriteLine($"{_description}\n");

    Ask();

    Console.Clear();
    Console.Write("Get ready... ");
    ShowSpinner(3);
  }

  public void DisplayEndingMessage()
  {
    Console.Write("\nWell done!! ");
    ShowSpinner(3);
    Console.Write($"\nYou have completed another {_duration} seconds of the {_name}. ");
    ShowSpinner(3);
  }

  public void ShowSpinner(int seconds)
  {
    DateTime startTime = DateTime.Now;
    DateTime timeToEnd = startTime.AddSeconds(seconds);
    DateTime currentTime;

    do
    {
      foreach (char spin in _spinner)
      {
        Console.Write(spin);
        Thread.Sleep(100);
        Console.Write("\b \b");
      }

      currentTime = DateTime.Now;
    } while (currentTime < timeToEnd);

    Console.WriteLine();
  }

  public void ShowCountDown(int seconds)
  {
    for (int i = seconds; i > 0; i--)
    {
      Console.Write(i);
      Thread.Sleep(1000);
      Console.Write("\b \b");
    }

    Console.WriteLine();
  }
}