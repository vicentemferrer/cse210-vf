public abstract class Goal
{
  public string _shortName { get; private set; }
  protected string _description;
  protected int _points;

  public Goal(string name, string description, int points)
  {
    _shortName = name;
    _description = description;
    _points = points;
  }

  public virtual string GetDetailString()
  {
    string isChecked = IsComplete() ? "X" : " ";
    return $"[{isChecked}] {_shortName} ({_description})";
  }

  public abstract int RecordEvent();
  public abstract bool IsComplete();
  public abstract string GetStringRepresentation();
}