using System.Media;

public class ReadScriptureActivity : Activity
{
  private int _duration;
  private ScriptureReference _reference;
  private PromptGenerator _prompt;
  private SoundPlayer _alarm;

  public ReadScriptureActivity(string name, string description, ScriptureReference reference) : base(name, description)
  {
    _reference = reference;
    _prompt = new PromptGenerator(
      new List<string> { "What message is this passage trying to convey?", "How can I apply this message in my daily life?", "What can I learn from the biblical characters in this passage?", "How can I share this message with others?", "What can I do to improve my relationship with God?" }
    );
    _alarm = new SoundPlayer("alarmSound.wav");
  }

  public override void Run()
  {
    DisplayStartingMessage();
    DisplayPrompt();

    Console.Write("You may begin in: ");
    ShowCountdown(5);

    Console.Write("\nTime left: ");
    Timer(_duration);

#pragma warning disable CA1416
    _alarm.PlaySync();
#pragma warning restore CA1416

    AskForScripture();

    DisplayEndingMessage();
  }

  protected override void Ask()
  {
    Console.Write("How long, in minutes, would you like for your session? ");
    _actInput.Ask();
    _duration = _actInput.GetInputValue() * 60;
  }

  private void DisplayPrompt()
  {
    Console.Clear();
    Console.WriteLine("Consider the following question during your study session:\n");
    Console.WriteLine($" --- {_prompt.GetRandomPrompt()} --- ");
    Console.Write("\nPress enter to start the session ");
    _actInput.Ask();

    Console.WriteLine();
  }

  private void AskForScripture()
  {
    string bookName;
    int chapter, startVerse, endVerse;

    Console.WriteLine("\nWhich book did you open for your study today?");
    Console.Write(">>> ");
    _actInput.Ask();
    bookName = _actInput.GetInputText();

    Console.WriteLine("\nWhat was the chapter number where you read?");
    Console.Write(">>> ");
    _actInput.Ask();
    chapter = _actInput.GetInputValue();

    Console.WriteLine("\nIn which verse did you start?");
    Console.Write(">>> ");
    _actInput.Ask();
    startVerse = _actInput.GetInputValue();

    Console.WriteLine("\nIn which verse did you end?");
    Console.Write(">>> ");
    _actInput.Ask();
    endVerse = _actInput.GetInputValue();

    _reference.UpdateReference(bookName, chapter, startVerse, endVerse);
  }

  private void Timer(int seconds)
  {
    for (int i = seconds; i > 0; i--)
    {
      Console.Write(TimeTemplate(i));
      Thread.Sleep(1000);
      Console.Write("\b\b\b\b\b     \b\b\b\b\b");
    }

    Console.WriteLine();
  }

  private string TimeTemplate(int secs)
  {
    string minutes = TimeParse(secs / 60);
    string seconds = TimeParse(secs % 60);

    return $"{minutes}:{seconds}";
  }

  private string TimeParse(int number)
  {
    return number > 9 ? $"{number}" : $"0{number}";
  }
}