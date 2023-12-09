public class Entry
{
  public string _entryDate { get; private set; }
  private string _entryScripture;
  private string _entryText;

  public Entry(string date, string scripture, string entry)
  {
    _entryDate = date;
    _entryScripture = scripture;
    _entryText = entry;
  }

  public void BriefDisplay()
  {
    Console.WriteLine($"Date: {_entryDate} - Scripture: {_entryScripture}");
  }

  public void Display()
  {
    Console.WriteLine($"Date: {_entryDate} - Scripture: {_entryScripture}\n");
    Console.WriteLine($"{_entryText}\n");
  }

  public string GetStringRepresentation()
  {
    return $"Entry:{_entryDate},{_entryScripture},{_entryText}";
  }
}