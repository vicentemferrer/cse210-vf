public class Application
{
  private Journal _journal;
  private ScriptureProgress _progress;
  private ScriptureReference _currentReference;
  private UserInput _input;
  private List<string> _options;

  public Application()
  {
    _journal = new Journal();
    _progress = new ScriptureProgress();
    _currentReference = new ScriptureReference();
    _input = new UserInput();
    _options = new List<string> { "Read scriptures", "Read study journal", "Write journal", "Save journal", "Load journal", "Exit" };
  }

  public void Start()
  {
    do
    {
      Console.Clear();
      Console.WriteLine("Menu options:\n");
      for (int i = 0; i < _options.Count; i++)
      {
        Console.WriteLine($"\t{i + 1}. {_options[i]}");
      }
      Console.WriteLine();
      Console.Write("Select a choice from the menu: ");
      _input.Ask();
      Console.WriteLine();

      DispatchActions(_input.GetInputValue());
    } while (!_input.CompareInput("6"));
  }

  private void DispatchActions(int action)
  {
    if (action != 6) Console.Clear();

    switch (action)
    {
      case 1:
        CreateReadScriptureActivity(_currentReference).Run();
        break;
      case 2:
        CreateReadJournalActivity(_journal).Run();
        break;
      case 3:
        CreateWriteJournalActivity(_journal, _currentReference).Run();
        break;
      case 4:
        //SaveGoals();
        break;
      case 5:
        //LoadGoals();
        break;
      case 6:
        break;
      default:
        Console.WriteLine("Sorry, not valid option");
        return;
    }
  }

  private ReadScriptureActivity CreateReadScriptureActivity(ScriptureReference reference)
  {
    string name = "";
    string description = "";

    return new ReadScriptureActivity(name, description, reference);
  }

  private ReadJournalActivity CreateReadJournalActivity(Journal journal)
  {
    string name = "";
    string description = "";

    return new ReadJournalActivity(name, description, journal);
  }

  private WriteJournalActivity CreateWriteJournalActivity(Journal journal, ScriptureReference reference)
  {
    string name = "";
    string description = "";

    return new WriteJournalActivity(name, description, journal, reference);
  }
}