using System;
using System.IO;

public class GoalManager
{
    private List<Goal> _goal;
    private int _score;

    public GoalManager()
    {
        _goal = new List<Goal>();
        _score = 0;
    }

    public void star()
    {
        while(true)
        {
            Console.WriteLine("1. Create a Goal\n2. List Goals\n3. Record Event\n4. Display Player Info\n5. Save Goals\n6. Load Goals\n7. Exit\nYour choice: ");
            string choice = Console.ReadLine();
            if (int.Parse(choice) == 1)
            {
                CreateGoal();
            }

            else if (int.Parse(choice) == 2)
            {
                ListeGoalName();
            }

            else if (int.Parse(choice) == 3)
            {
                RecordEvent();
            }

            else if (int.Parse(choice) == 4)
            {
                DisplayPlayerInfo();
            }

            else if (int.Parse(choice) == 5)
            {
                SaveGoal();
            }

            else if (int.Parse(choice) == 6)
            {
                LoadGoal();
            }

            else
            {
                break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nPlayer Score: {_score}");
    }

    public void ListeGoalName()
    {
        foreach(Goal goal in _goal)
        {
            Console.WriteLine(goal.GetName());
        }
    }
    public void ListGoalDetail()
    {
        Console.WriteLine("\n--- Goals ---");
        foreach (Goal goal in _goal)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
        
    }
    public void CreateGoal()
    {
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Choose goal type: ");
        string type = Console.ReadLine();

        Console.Write(" what is the name of goal? ");
        string name = Console.ReadLine();

        Console.Write(" what is the description of goal? ");
        string description = Console.ReadLine();

        Console.Write(" what is the points of goal? ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
        {
            _goal.Add(new SimpleGoal(description, points));
        }
        else if (type == "2")
        {
            _goal.Add(new EternalGoal(description, points));
        }
        else if (type == "3")
        {
            Console.Write("Target count: ");
            int targetCount = int.Parse(Console.ReadLine());

            Console.Write("Bonus points: ");
            int bonus = int.Parse(Console.ReadLine());

            _goal.Add(new ChecklistGoal(name, description, points, targetCount, bonus));
        }
    }
    public void RecordEvent()
    {
        Console.WriteLine("Select a goal to record an event:");
        for (int i = 0; i < _goal.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goal[i].GetDetailsString()}");
        }

        Console.Write("Your choice: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < _goal.Count)
        {
            _goal[index].RecordEvent();
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
    }
    public void SaveGoal()
    {
        string fileName = "/week06/EternalQuest/goal.txt";

        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.WriteLine("This will be the first line in the file. elsy");

            string color = "Blue";
            outputFile.WriteLine($"My favorite color is {color}");
        }

        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine($"Player Score: {_score}");

            foreach (Goal goal in _goal)
            {
                string line = goal.GetstringRepresentation();
                writer.WriteLine(line); 
            }
        }
        Console.WriteLine("The goals have been successfully saved.");

    }
    public void LoadGoal()
    {
            // Lire le score total
            string fileName = "/week06/EternalQuest/goal.txt";
            string[] lines = System.IO.File.ReadAllLines(fileName);
            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts[0] == "SimpleGoal")
                {
                    _goal.Add(new SimpleGoal( parts[2], int.Parse(parts[3])));
                }
                else if (parts[0] == "EternalGoal")
                {
                    _goal.Add(new EternalGoal( parts[2], int.Parse(parts[3])));
                }

                else if (parts[0] == "ChecklistGoal")
                {
                    _goal.Add(new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]),
                    int.Parse(parts[4]), int.Parse(parts[6])));
                }
            }
            Console.WriteLine("The goals have been successfully loaded.");     
    }
}