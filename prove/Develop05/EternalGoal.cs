public class EternalGoal : Goal
{
  public EternalGoal(string name, string description, int points) : base(name, description, points)
  { }

  public override int RecordEvent()
  {
    Console.WriteLine($"Congratulations! You have earned {_points} points!");
    return _points;
  }

  public override bool IsComplete()
  {
    return false;
  }

  public override string GetStringRepresentation()
  {
    return $"EternalGoal:{_shortName},{_description},{_points}";
  }
}