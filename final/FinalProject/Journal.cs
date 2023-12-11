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
    Console.WriteLine();
    foreach (Entry entry in _entries)
      entry.BriefDisplay();
  }

  public void DisplayMatched(string date)
  {
    Console.WriteLine();
    foreach (Entry entry in _entries)
      if (date == entry._entryDate) entry.Display();
  }

  public string SaveJournal()
  {
    string journal = "";
    foreach (Entry entry in _entries)
      journal += $"{entry.GetStringRepresentation()}\n";

    return journal;
  }

  public void LoadJournal(List<string> journal)
  {
    List<string> entryContent = new List<string>();

    foreach (string line in journal)
    {
      string[] parts = line.Split(',');

      string[] content = parts[2].Split('|');

      foreach (string section in content)
        entryContent.Add(section);

      Entry entry = new Entry(parts[0], parts[1], entryContent);

      AddEntry(entry);
    }
  }
}