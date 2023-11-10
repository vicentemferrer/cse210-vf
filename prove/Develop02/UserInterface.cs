public class UserInterface
{
  private bool _exit = false;
  private List<string> _options;
  private Journal _journal;
  private WriteEntryUI _writeUi;
  private ManageFilesUI _fileAdmin;
  private UserInput _input = new UserInput();

  public UserInterface(DateTime date, Journal journal, List<string> options, List<string> prompts)
  {
    _journal = journal;
    _options = options;
    _writeUi = new WriteEntryUI(date, journal, prompts);
    _fileAdmin = new ManageFilesUI(journal);
  }

  public bool _Exit
  {
    get => _exit;
  }

  public void DisplayActions()
  {
    Console.WriteLine("Please select one of the following actions: \n");

    for (int i = 0; i < _options.Count; i++)
    {
      Console.WriteLine($"{i + 1}. {_options[i]}");
    }
  }

  public void CatchingAction()
  {
    Console.Write("What would you like to do? ");
    _input.Ask();
  }

  public void Action()
  {
    int action = int.Parse(_input.GetInputText());

    switch (action)
    {
      case 1:
        _writeUi.WriteEntry();
        break;
      case 2:
        _journal.DisplayAll();
        break;
      case 3:
        _fileAdmin.Load();
        break;
      case 4:
        _fileAdmin.Save();
        break;
      case 5:
        _exit = !_exit;
        break;
      default:
        Console.WriteLine("Sorry. Action not found.");
        break;
    }

    if (action != 5)
    {
      Console.Write("Press enter to continue...");
      Console.ReadLine();
      Console.Clear();
    }
    else
    {
      Console.WriteLine("Thanks for use our app!");
    }
  }
}