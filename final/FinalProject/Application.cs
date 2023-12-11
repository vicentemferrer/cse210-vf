public class Application
{
  private Journal _journal;
  private ScriptureProgress _progress;
  private ScriptureReference _currentReference;
  private FileManager _fileManager;
  private UserInput _input;
  private List<string> _options;

  public Application()
  {
    _journal = new Journal();
    _progress = new ScriptureProgress();
    _currentReference = new ScriptureReference();
    _fileManager = new FileManager();
    _input = new UserInput();
    _options = new List<string> { "Read scriptures", "Read study journal", "Write journal", "Show progress", "Update progress", "Save journal", "Load journal", "Exit" };
  }

  public async Task Start()
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

      await DispatchActions(_input.GetInputValue());
    } while (!_input.CompareInput("8"));
  }

  private async Task DispatchActions(int action)
  {
    if (action != 8) Console.Clear();

    try
    {
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
          ShowProgress();
          break;
        case 5:
          await UpdateProgress();
          break;
        case 6:
          _fileManager.Save(_journal, _progress);
          break;
        case 7:
          _fileManager.Load(_journal, _progress);
          break;
        case 8:
          break;
        default:
          Console.WriteLine("Sorry, not valid option");
          return;
      }
    }
    catch (Exception e)
    {
      HandleError(e);
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

  private async Task UpdateProgress()
  {
    ScriptureRequest request = new ScriptureRequest(_currentReference);
    await request.DispatchRequest(_progress);
  }

  private void ShowProgress()
  {
    Console.WriteLine("Your Scripture reading progress:\n");
    _progress.DisplayProgress();
    Console.Write("\nPress enter to continue ");
    _input.Ask();
  }

  private void HandleError(Exception error)
  {
    Console.WriteLine();
    Console.WriteLine(error.Message);
    Console.Write("\nPress enter to continue. ");
    _input.Ask();
  }
}