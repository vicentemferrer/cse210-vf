public class WriteEntryUI
{
  private string _date;
  private Journal _journal;
  private PromptGenerator _generator;
  private UserInput _input = new UserInput();

  public WriteEntryUI(DateTime date, Journal journal, List<string> prompts)
  {
    _date = date.ToShortDateString();
    _journal = journal;
    _generator = new PromptGenerator(prompts);
  }

  public void WriteEntry()
  {
    string prompt = _generator.GetRandomPrompt();

    Console.WriteLine(prompt);
    Console.Write(">> ");
    _input.Ask();

    _journal.AddEntry(new Entry(_date, prompt, _input.GetInputText()));
  }
}