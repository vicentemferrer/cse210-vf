public class UserInput
{
  private string _input;

  public UserInput() { }

  public string GetInputText()
  {
    return _input;
  }

  public int GetInputValue()
  {
    return int.Parse(_input);
  }

  public void Ask()
  {
    _input = Console.ReadLine().Trim();
  }
}