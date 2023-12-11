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

      await DispatchActions(_input.GetInputText());
    } while (!_input.CompareInput("8"));
  }

  private async Task DispatchActions(string actionInput)
  {
    if (actionInput != "8") Console.Clear();

    try
    {
      switch (actionInput)
      {
        case "1":
        case "2":
        case "3":
          CreateActivity(actionInput).Run();
          break;
        case "4":
          ShowProgress();
          break;
        case "5":
          await UpdateProgress();
          break;
        case "6":
          _fileManager.Save(_journal, _progress);
          break;
        case "7":
          _fileManager.Load(_journal, _progress);
          break;
        case "8":
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

  private Activity CreateActivity(string action)
  {
    switch (action)
    {
      case "1":
        return CreateReadScriptureActivity(_currentReference);
      case "2":
        return CreateReadJournalActivity(_journal);
      case "3":
        return CreateWriteJournalActivity(_journal, _currentReference);
      default:
        return null;
    }
  }

  private ReadScriptureActivity CreateReadScriptureActivity(ScriptureReference reference)
  {
    string name = "Read Scripture Activity";
    string description = "This activity will help you grow by guiding you through reading and understanding a passage of the Sacred Scriptures. Explore the historical and literary context of the text, and learn how it reveals God's character and plan. This activity will help you connect with God and His Word.";

    return new ReadScriptureActivity(name, description, reference);
  }

  private ReadJournalActivity CreateReadJournalActivity(Journal journal)
  {
    string name = "Read Journal Activity";
    string description = "This activity will help you grow by leading you through reading and thinking on your past experiences. Learn from your reflections and God's love signs registered in your journal. This activity will help you connect with God, your Heavenly Father.";

    return new ReadJournalActivity(name, description, journal);
  }

  private WriteJournalActivity CreateWriteJournalActivity(Journal journal, ScriptureReference reference)
  {
    string name = "Write Journal Activity";
    string description = "This activity will help you express your thoughts and feelings about the Scriptures in a creative and personal way. It involves writing a poem, a story, a song, or any other form of writing that is inspired by a passage of Scriptures. Write your own reflections and insights on the text. This activity will help you explore the richness and relevance of God's Word for your life.";

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