public class ListingActivity : Activity
{
  private int _count;
  private List<string> _prompts;
  private Random _democracy = new Random();

  public ListingActivity(string name, string description, List<string> prompts) : base(name, description)
  {
    _prompts = prompts;
  }

  public void Run()
  {
    DisplayStartingMessage();

    Console.WriteLine("\nList as many responses you can to the following prompt:\n");
    GetRandomPrompt();
    Console.Write("\nYou may begin in: ");
    ShowCountDown(5);

    _count = GetListFromUser().Count;

    Console.WriteLine($"You listed {_count} items!");

    DisplayEndingMessage();
  }

  private void GetRandomPrompt()
  {
    int index = _democracy.Next(_prompts.Count);
    Console.WriteLine($" --- {_prompts[index]} --- ");
  }

  private List<string> GetListFromUser()
  {
    List<string> answers = new List<string>();

    DateTime startTime = DateTime.Now;
    DateTime timeToEnd = startTime.AddSeconds(_duration);
    DateTime currentTime;

    Console.WriteLine();

    do
    {
      Console.Write("> ");
      _input.Ask();

      answers.Add(_input.GetInputText());

      currentTime = DateTime.Now;
    } while (currentTime < timeToEnd);

    Console.WriteLine();

    return answers;
  }
}