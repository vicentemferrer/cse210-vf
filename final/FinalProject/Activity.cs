public abstract class Activity
{
  private string _name;
  private string _description;
  protected UserInput _actInput;
  private char[] _spinner = new char[] { '|', '/', '-', '\\', '|', '/', '-', '\\' };

  public Activity(string name, string description)
  {
    _name = name;
    _description = description;
    _actInput = new UserInput();
  }

  public abstract void Run();

  protected virtual void Ask()
  {
    Console.Write("Press enter to continue ");
    _actInput.Ask();
  }

  protected void DisplayStartingMessage()
  {
    Console.Clear();
    Console.WriteLine($"Welcome to {_name}.\n");
    Console.WriteLine($"{_description}\n");

    Ask();

    Console.Clear();
    Console.Write("Get ready... ");
    ShowSpinner(3);
  }

  protected void DisplayEndingMessage()
  {
    Console.Write("\nWell done!! ");
    ShowSpinner(3);
    Console.Write($"\nReturning to menu ");
    ShowSpinner(3);
  }

  protected void ShowSpinner(int seconds)
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

  protected void ShowCountdown(int seconds)
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