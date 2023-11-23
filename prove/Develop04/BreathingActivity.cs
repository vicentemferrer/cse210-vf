public class BreathingActivity : Activity
{
  public BreathingActivity(string name, string description) : base(name, description)
  { }

  public void Run()
  {
    DisplayStartingMessage();

    DateTime startTime = DateTime.Now;
    DateTime timeToEnd = startTime.AddSeconds(_duration);
    DateTime currentTime;

    do
    {
      Breathe("\nBreathe in... ", 4);
      Breathe("Now breathe out... ", 6);

      currentTime = DateTime.Now;
    } while (currentTime < timeToEnd);

    DisplayEndingMessage();
  }

  private void Breathe(string prompt, int seconds)
  {
    Console.Write(prompt);
    ShowCountDown(seconds);
  }
}