public class WriteJournalActivity : Activity
{
  private Journal _journal;
  private ScriptureReference _reference;

  public WriteJournalActivity(string name, string description, Journal journal, ScriptureReference reference) : base(name, description)
  {
    _journal = journal;
    _reference = reference;
  }

  public override void Run()
  {
    List<string> content;

    DisplayStartingMessage();
    Console.Write("\nYou may begin in: ");
    ShowCountdown(5);

    content = WriteEntry();

    _journal.AddEntry(new Entry(DateTime.Now.ToShortDateString(), _reference.GetStringRepresentation(), content));

    DisplayEndingMessage();
  }

  public List<string> WriteEntry()
  {
    List<string> answers = new List<string>();

    Console.WriteLine();

    do
    {
      Console.Write(">>> ");
      _actInput.Ask();

      if (!_actInput.CompareInput("exit")) answers.Add(_actInput.GetInputText());
    } while (!_actInput.CompareInput("exit"));

    Console.WriteLine();

    return answers;
  }
}