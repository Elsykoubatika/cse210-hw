using System;
using System.Collections.Generic;
using System.IO;

using System.Text.Json;

public class GoalManager
{
    private List<Goal> _goal;
    private int _score;

    public GoalManager()
    {
        _goal = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool travail = true;

        while (travail == true)
        {
            Console.WriteLine();
            Console.WriteLine("=== Eternal Quest — Menu ===");
            Console.WriteLine("1. List Goal");
            Console.WriteLine("2. Create a goal");
            Console.WriteLine("3. Save goals");
            Console.WriteLine("4. Load goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Choice: ");
            string choice = Console.ReadLine()?.Trim();
            Console.WriteLine();
            if (choice == "1")
            {
                ListGoalDetails();
            }
            else if (choice == "2")
            {
                CreateGoal();
            }
            else if (choice == "5")
            {
                RecordEvent();
            }
            else if (choice == "3")
            {
                SaveGoals();
            }
            else if (choice == "4")
            {
                LoadGoals();
            }
            else if (choice == "6")
            {
                travail = false;
            }
            else
            {
                Console.WriteLine("Choix invalide.");
            }
        }
    }

    public int GetScore()
    {
        return _score;
    }
    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nPlayer Score: {_score}");
        Console.WriteLine($"Number of goals: {_goal.Count}");
    }

    public void ListGoalNames()
    {
        foreach(Goal goal in _goal)
        {
            Console.WriteLine(goal.GetName());
        }
    }
    public void ListGoalDetails()
    {

        if (_goal.Count == 0) { Console.WriteLine("No goals."); return; }
        for (int i = 0; i < _goal.Count; i++)
        {
            DisplayPlayerInfo();
            Console.WriteLine($"{i + 1}. {_goal[i].GetDetailsString()}");
        }
        
    }
    public void CreateGoal()
    {
        Console.WriteLine("What type of goal do you want to create?");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Choose goal type: ");
        string type = Console.ReadLine();

        Console.Write(" what is the name of goal?: ");
        string name = Console.ReadLine();

        Console.Write(" what is the description of goal?: ");
        string description = Console.ReadLine();

        Console.Write(" what is the points of goal?: ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
        {
            _goal.Add(new SimpleGoal(name, description, points));
            Console.WriteLine("SimpleGoal created.");
        }
        else if (type == "2")
        {
            _goal.Add(new EternalGoal(name, description, points));
            Console.WriteLine("EternalGoal created.");
        }
        else if (type == "3")
        {
            int targetCount;
            while (true)
            {
                Console.Write("Target count: ");
                string input = Console.ReadLine()?.Trim();
                if (int.TryParse(input, out targetCount) && targetCount > 0) break;
                Console.WriteLine("");
            }

            int bonus;
            while (true)
            {
                Console.Write("Bonus points: ");
                string input = Console.ReadLine()?.Trim();
                if (int.TryParse(input, out bonus) && bonus >= 0) break;
                Console.WriteLine("");
            }

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
            _score += _goal[index].GetPointe();
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
    }
    public void SaveGoals()  
    {
        string fileName = "goal.txt";
        if (string.IsNullOrWhiteSpace(fileName)) return;

        try
        {
            using var sw = new StreamWriter(fileName);


            sw.WriteLine($"SCORE|{_score}");
            foreach (var g in _goal)
            {
                sw.WriteLine(g.GetstringRepresentation());
            }
            Console.WriteLine($" Goals saved to '{fileName}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"error: {ex.Message}");
        }
    }
    public void LoadGoals()
    {
        string fileName = "goal.txt";
        if (string.IsNullOrWhiteSpace(fileName) || !File.Exists(fileName))
        {
            Console.WriteLine("File not found.");
            return;
        }
        try
        {
            string[] lines = File.ReadAllLines(fileName);
            var newList = new List<Goal>();
            int loadedScore = 0;

            foreach (var rawLine in lines)
            {
                var raw = rawLine?.Trim();
                if (string.IsNullOrEmpty(raw)) continue;

                var parts = raw.Split('|');
                if (parts.Length == 0) continue;

                var type = parts[0];

                // Ligne score : SCORE|123
                if (type == "SCORE" && parts.Length >= 2)
                {
                    if (int.TryParse(parts[1], out int sc)) loadedScore = sc;
                    continue;
                }

                switch (type)
                {
                    case "Simple" when parts.Length >= 5:
                        {
                            string name = parts[1];
                            string description = parts[2];
                            int points = int.TryParse(parts[3], out var p1) ? p1 : 0;
                            bool done = parts[4] == "1";
                            var g = new SimpleGoal(name, description, points);
                            if (done) g.RecordEvent();
                            newList.Add(g);
                            break;
                        }

                    case "Eternal" when parts.Length >= 5:
                        {
                            string name = parts[1];
                            string description = parts[2];
                            int points = int.TryParse(parts[3], out var p2) ? p2 : 0;
                            int times = int.TryParse(parts[4], out var t) ? t : 0;
                            var g = new EternalGoal(name, description, points);
                            for (int i = 0; i < times; i++) g.RecordEvent();
                            newList.Add(g);
                            break;
                        }

                    case "Checklist" when parts.Length >= 8:
                        {
                            string name = parts[1];
                            string description = parts[2];
                            int points = int.TryParse(parts[3], out var p3) ? p3 : 0;
                            int amount = int.TryParse(parts[4], out var a) ? a : 0;
                            int target = int.TryParse(parts[5], out var tgt) ? tgt : 1;
                            int bonus = int.TryParse(parts[6], out var b) ? b : 0;
                            bool bonusGiven = parts[7] == "1";

                            var g = new ChecklistGoal(name, description, points, target, bonus);
                            for (int i = 0; i < amount; i++) g.RecordEvent();
                            newList.Add(g);
                            break;
                        }

                    default:
                        Console.WriteLine($"Ligne non reconnue (skipped): {raw}");
                        break;
                }
            }

            _goal = newList;
            _score = loadedScore;
            Console.WriteLine($"Chargé {_goal.Count} objectifs. Score = {_score}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur lecture: {ex.Message}");
        }
    }
}