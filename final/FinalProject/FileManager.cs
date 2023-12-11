public class FileManager
{
  private UserInput _fileInput;

  public FileManager()
  {
    _fileInput = new UserInput();
  }

  private string FilenameSetter()
  {
    Console.WriteLine("What is the filename?");
    Console.Write(">>> ");
    _fileInput.Ask();
    return _fileInput.GetInputText();
  }

  public void Save(Journal journal, ScriptureProgress progress)
  {
    string filename = FilenameSetter();
    using (StreamWriter outputFile = new StreamWriter(filename))
    {
      outputFile.WriteLine(progress.GetStringRepresentation());
      outputFile.WriteLine(journal.SaveJournal());
    }
  }


  public void Load(Journal journal, ScriptureProgress progress)
  {
    string filename = FilenameSetter();
    string[] lines = File.ReadAllLines(filename);

    int[] verseProgress = new int[5];
    List<string> entriesJournal = new List<string>();

    foreach (string line in lines)
    {
      string[] sections = line.Split(';');

      if (sections[0] == "Progress")
      {
        string[] verseAmounts = sections[1].Split(',');

        verseProgress = verseAmounts.Select(amount => int.Parse(amount)).ToArray();

        continue;
      }

      if (sections[0] == "Entry")
      {
        entriesJournal.Add(sections[1]);
      }
    }

    progress.LoadProgress(verseProgress);
    journal.LoadJournal(entriesJournal);
  }
}