public class PromptGenerator
{
  private List<string> _prompts = new List<string>();
  private Random _pointer = new Random();

  public PromptGenerator(List<string> prompts)
  {
    _prompts = prompts;
  }

  public string GetRandomPrompt()
  {
    int index = _pointer.Next(0, _prompts.Count);
    return _prompts[index];
  }
}