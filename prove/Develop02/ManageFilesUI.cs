public class ManageFilesUI
{
  private Journal _journal;
  private UserInput _input = new UserInput();

  public ManageFilesUI(Journal journal)
  {
    _journal = journal;
  }

  private string FilenameSetter()
  {
    Console.WriteLine("What is the filename?");
    Console.Write(">> ");
    _input.Ask();
    return _input.GetInputText();
  }

  public void Save()
  {
    string filename = FilenameSetter();
    _journal.SaveToFile(filename);
  }

  public void Load()
  {
    string filename = FilenameSetter();
    _journal.LoadFromFile(filename);
  }
}