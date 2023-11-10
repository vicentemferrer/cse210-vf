public class Entry
{
  private string _entryDate;
  private string _entryPrompt;
  private string _entryText;

  public Entry(string date, string prompt, string entry)
  {
    _entryDate = date;
    _entryPrompt = prompt;
    _entryText = entry;
  }

  public string _EntryDate
  {
    get => _entryDate;
  }

  public string _EntryPrompt
  {
    get => _entryPrompt;
  }

  public string _EntryText
  {
    get => _entryText;
  }

  public void Display()
  {
    Console.WriteLine($"Date: {_entryDate} - Prompt: {_entryPrompt}");
    Console.WriteLine($"{_entryText}\n");
  }
}