public class Assignment
{
  private string _studentName;
  private string _topic;

  public Assignment(string name, string topic)
  {
    _studentName = name;
    _topic = topic;
  }

  protected string _StudentName { get => _studentName; }

  public string GetSummary()
  {
    return $"{_studentName} - {_topic}";
  }
}