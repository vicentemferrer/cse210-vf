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
      entry.BriefDisplay();
  }

  public void DisplayMatched(string date)
  {
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
    foreach (string line in journal)
    {
      string[] parts = line.Split(",");

      Entry entry = new Entry(parts[0], parts[1], parts[2]);

      AddEntry(entry);
    }
  }
}