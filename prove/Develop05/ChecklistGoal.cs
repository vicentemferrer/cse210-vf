public class ChecklistGoal : Goal
{
  private int _amountCompleted;
  private int _target;
  private int _bonus;

  public ChecklistGoal(string name, string description, int points, int bonus, int target, int amountCompleted = 0) : base(name, description, points)
  {
    _target = target;
    _bonus = bonus;
    _amountCompleted = amountCompleted;
  }

  public override int RecordEvent()
  {
    _amountCompleted++;
    int total = IsComplete() ? _points + _bonus : _points;
    Console.WriteLine($"Congratulations! You have earned {total} points!");
    return total;
  }

  public override bool IsComplete()
  {
    return _amountCompleted >= _target;
  }

  public override string GetStringRepresentation()
  {
    return $"ChecklistGoal:{_shortName},{_description},{_points},{_bonus},{_target},{_amountCompleted}";
  }

  public override string GetDetailString()
  {
    string isChecked = IsComplete() ? "X" : " ";
    return $"[{isChecked}] {_shortName} ({_description}) -- Currently completed: {_amountCompleted}/{_target}";
  }
}