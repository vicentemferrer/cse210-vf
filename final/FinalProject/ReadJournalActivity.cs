public class ReadJournalActivity : Activity
{
  private Journal _journal;

  public ReadJournalActivity(string name, string description, Journal journal) : base(name, description)
  {
    _journal = journal;
  }

  public override void Run()
  {
    DisplayStartingMessage();
    DisplayAll();

    Console.Write("\nDo you want to read a specific entry from your journal? (y/n) ");
    _actInput.Ask();

    if (_actInput.CompareInput("y")) DisplaySelected();

    DisplayEndingMessage();
  }

  private void DisplayAll()
  {
    Console.Clear();
    Console.WriteLine("Journal entries:");
    _journal.DisplayAll();
    Console.Write("\nPress enter to continue ");
    _actInput.Ask();
  }

  private void DisplaySelected()
  {
    Console.Clear();
    Console.Write("Enter entry date to search (MM-DD-YYYY / DD-MM-YYYY): ");
    _actInput.Ask();

    Console.WriteLine("\nJournal entries selected:");
    _journal.DisplayMatched(DateTime.Parse(_actInput.GetInputText()).ToShortDateString());
    Console.Write("\nPress enter to continue ");
    _actInput.Ask();

    Console.WriteLine();
  }
}