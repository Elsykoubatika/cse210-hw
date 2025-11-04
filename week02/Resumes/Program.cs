using System;

class Program
{
    static void Main(string[] args)
    {
        Job Job1 = new Job();
        Job1._jobTitle = "Software Developer";
        Job1._company = "Tech Corp";
        Job1._startYear = 2018;
        Job1._endYear = 2020;

        Job Job2 = new Job();
        Job2._jobTitle = "Web Developer";
        Job2._company = "Web Solutions Inc.";
        Job2._startYear = 2020;
        Job2._endYear = 2022;

        Resume myResume = new Resume();
        myResume._jobs.Add(Job1);
        myResume._jobs.Add(Job2);
        myResume._name = "John Doe";

        myResume.DisplayResume();
    }
}