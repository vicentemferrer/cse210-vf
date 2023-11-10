public class Journal
{
  private List<Entry> _entries = new List<Entry>();

  public Journal() { }

  public void AddEntry(Entry newEntry)
  {
    _entries.Add(newEntry);
  }

  public void DisplayAll()
  {
    foreach (Entry entry in _entries)
      entry.Display();
  }

  public void SaveToFile(string filename)
  {
    using (StreamWriter outputFile = new StreamWriter(filename))
    {
      foreach (Entry entry in _entries)
      {
        outputFile.WriteLine($"{entry._EntryDate};{entry._EntryPrompt};{entry._EntryText}");
      }
    }
  }

  public void LoadFromFile(string filename)
  {
    string[] lines = System.IO.File.ReadAllLines(filename);

    foreach (string line in lines)
    {
      string[] parts = line.Split(";");

      Entry entry = new Entry(parts[0], parts[1], parts[2]);

      AddEntry(entry);
    }
  }
}