public class Entry
{
  public string _entryDate { get; private set; }
  private string _entryScripture;
  private List<string> _entryContent;

  public Entry(string date, string scripture, List<string> entry)
  {
    _entryDate = date;
    _entryScripture = scripture;
    _entryContent = entry;
  }

  public void BriefDisplay()
  {
    Console.WriteLine($"\nDate: {_entryDate} - Scripture: {_entryScripture}");
  }

  public void Display()
  {
    Console.WriteLine($"\nDate: {_entryDate} - Scripture: {_entryScripture}\n");

    foreach (string line in _entryContent)
    {
      Console.WriteLine('\t' + line);
    }

    Console.WriteLine();
  }

  public string GetStringRepresentation()
  {
    return $"Entry;{_entryDate},{_entryScripture},{string.Join('|', _entryContent)}";
  }
}