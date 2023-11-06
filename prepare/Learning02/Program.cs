using System;

class Program
{
    static void Main(string[] args)
    {
        Resume myResume = new Resume();

        Job job1 = new Job();
        Job job2 = new Job();

        myResume._name = "Vicente Ferrer";

        job1._jobTitle = "Software Engineer";
        job1._company = "Microsoft";
        job1._startYear = 2019;
        job1._endYear = 2022;

        job2._jobTitle = "Manager";
        job2._company = "Apple";
        job2._startYear = 2022;
        job2._endYear = 2023;

        myResume._jobList.AddRange(new List<Job>() { job1, job2 });

        myResume.Display();
    }
}