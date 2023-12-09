public class UserInput
{
  private string _input;

  public string GetInputText()
  {
    return _input;
  }

  public int GetInputValue()
  {
    return int.Parse(_input);
  }

  public bool CompareInput(string matchCase)
  {
    return _input.ToLower() == matchCase.ToLower();
  }

  public void Reset()
  {
    _input = "";
  }

  public void Ask()
  {
    _input = Console.ReadLine().Trim();
  }
}