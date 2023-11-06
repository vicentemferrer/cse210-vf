using System.Collections.Generic;

public class Resume
{
  public string _name;
  public List<Job> _jobList = new List<Job>();

  public Resume() { }

  public void Display()
  {
    Console.WriteLine($"Name: {this._name}\nJobs:");
    foreach (Job job in this._jobList)
      job.Display();
  }
}