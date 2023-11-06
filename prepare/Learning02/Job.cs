public class Job
{
  public string _company;
  public string _jobTitle;
  public int _startYear;
  public int _endYear;

  public Job() { }

  public void Display()
  {
    Console.WriteLine($"{this._jobTitle} ({this._company}) {this._startYear}-{this._endYear}");
  }
}