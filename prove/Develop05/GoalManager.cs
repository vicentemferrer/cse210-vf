public class GoalManager
{
  private List<string> _options;
  private List<string> _types;
  private List<Goal> _goals;
  private UserInput _input;
  private int _score;

  public GoalManager()
  {
    _options = new List<string> { "Create new goal", "List goals", "Record event", "Save goals", "Load goals", "Quit" };
    _types = new List<string> { "Simple", "Eternal", "Checklist" };
    _goals = new List<Goal>();
    _input = new UserInput();
    _score = 0;
  }

  public void Start()
  {
    do
    {
      Console.Clear();
      DisplayPlayerInfo();
      Console.WriteLine("Menu options:\n");
      for (int i = 0; i < _options.Count; i++)
      {
        Console.WriteLine($"\t{i + 1}. {_options[i]}");
      }
      Console.WriteLine();
      Console.Write("Select a choice from the menu: ");
      _input.Ask();
      Console.WriteLine();

      DispatchActions(_input.GetInputValue());
    } while (_input.GetInputText() != "6");
  }

  private void DisplayPlayerInfo()
  {
    Console.WriteLine($"\nYou have {_score} points.\n");
  }

  private void DispatchActions(int action)
  {
    if (action != 6) Console.Clear();

    switch (action)
    {
      case 1:
        CreateGoal();
        break;
      case 2:
        ListGoalDetails();
        break;
      case 3:
        RecordEvent();
        break;
      case 4:
        SaveGoals();
        break;
      case 5:
        LoadGoals();
        break;
      case 6:
        break;
      default:
        Console.WriteLine("Sorry, not valid option");
        return;
    }

    if (action != 6)
    {
      Console.Write("\nPress enter to continue. ");
      _input.Ask();
    }
  }

  private void CreateGoal()
  {
    bool validEntry = false;
    do
    {
      try
      {
        Console.WriteLine("The types of goals are:");
        ListTypesGoals();
        Console.Write("Which type of goal would you like to create? ");
        _input.Ask();
        Console.WriteLine();

        var goal = CollectGoalDetails(_input.GetInputValue());

        validEntry = goal != null;

        if (validEntry)
          _goals.Add(goal);
        else
        {
          Console.WriteLine("\nSorry, unexpected type. Try again!\n");
          _input.Ask();
        }
      }
      catch (Exception error)
      {
        HandleError(error);
      }
    } while (!validEntry);
  }

  private void ListGoalDetails()
  {
    Console.WriteLine("The goals are:");
    Console.WriteLine();
    for (int i = 0; i < _goals.Count; i++)
    {
      Console.WriteLine($"\t{i + 1}. {_goals[i].GetDetailString()}");
    }
    Console.WriteLine();
  }

  private void RecordEvent()
  {
    bool validEntry = false;
    int value;

    do
    {
      try
      {
        Console.WriteLine("The goals are:");
        ListGoalName();
        Console.Write("What goal did you accomplish? ");
        _input.Ask();
        Console.WriteLine();

        validEntry = int.TryParse(_input.GetInputText(), out value);

        if (validEntry)
        {
          _score += _goals[value - 1].RecordEvent();
          CompletedGoals();
          Console.WriteLine($"\nYou now have {_score} points.");
        }
        else
        {
          Console.WriteLine("\nSorry, invalid option. Try again!\n");
          _input.Ask();
        }
      }
      catch (Exception error)
      {
        HandleError(error);
      }
    } while (!validEntry);
  }

  private void SaveGoals()
  {
    string filename = FilenameSetter();
    using (StreamWriter outputFile = new StreamWriter(filename))
    {
      outputFile.WriteLine(_score);
      foreach (Goal entry in _goals)
      {
        outputFile.WriteLine(entry.GetStringRepresentation());
      }
    }
  }

  private void LoadGoals()
  {
    string filename = FilenameSetter();
    string[] lines = System.IO.File.ReadAllLines(filename);
    _goals = new List<Goal>();

    foreach (string line in lines)
    {
      string name, description;
      int points, target = 0, bonus = 0, amountCompleted = 0;
      bool isComplete = false, validEntry;

      if (line == lines[0])
      {
        _score = int.Parse(line);
        continue;
      }

      string[] parts = line.Split(":");

      string type = parts[0];
      string[] props = parts[1].Split(",");

      name = props[0];
      description = props[1];
      points = int.Parse(props[2]);

      if (props.Length == 4)
      {
        validEntry = bool.TryParse(props[3], out isComplete);
      }

      if (props.Length == 6)
      {
        validEntry = int.TryParse(props[3], out bonus);
        validEntry = int.TryParse(props[4], out target);
        validEntry = int.TryParse(props[5], out amountCompleted);
      }

      var goal = GenerateGoal(type.Substring(0, type.Length - (type.Length - type.IndexOf("Goal"))), name, description, points, isComplete, bonus, target, amountCompleted);

      if (goal != null) _goals.Add(goal);
    }
  }

  private void ListGoalName()
  {
    Console.WriteLine();
    for (int i = 0; i < _goals.Count; i++)
    {
      Console.WriteLine($"\t{i + 1}. {_goals[i]._shortName}");
    }
    Console.WriteLine();
  }

  private void ListTypesGoals()
  {
    Console.WriteLine();
    for (int i = 0; i < _types.Count; i++)
    {
      Console.WriteLine($"\t{i + 1}. {_types[i]} Goal");
    }
    Console.WriteLine();
  }

  private Goal? CollectGoalDetails(int type)
  {
    string name, description;
    int points, target = 0, bonus = 0;

    Console.Write("What is the name of your goal? ");
    _input.Ask();
    name = _input.GetInputText();
    Console.Write("What is a short description of it? ");
    _input.Ask();
    description = _input.GetInputText();
    Console.Write("What is the amount of points associated with this goal? ");
    _input.Ask();
    points = _input.GetInputValue();

    if (type - 1 == _types.IndexOf("Checklist"))
    {
      Console.Write("How many times does this goal need to be accomplished for a bonus? ");
      _input.Ask();
      target = _input.GetInputValue();
      Console.Write("What is the bonus for accomplishing it that many times? ");
      _input.Ask();
      bonus = _input.GetInputValue();
    }

    return GenerateGoal(_types[type - 1], name, description, points, false, bonus, target);
  }

  private string FilenameSetter()
  {
    Console.WriteLine("What is the filename?");
    Console.Write(">> ");
    _input.Ask();
    return _input.GetInputText();
  }

  private Goal? GenerateGoal(string type, string name, string description, int points, bool isComplete = false, int bonus = 0, int target = 0, int amountCompleted = 0)
  {
    switch (type)
    {
      case "Simple":
        return new SimpleGoal(name, description, points, isComplete);
      case "Eternal":
        return new EternalGoal(name, description, points);
      case "Checklist":
        return new ChecklistGoal(name, description, points, bonus, target, amountCompleted);
      default:
        return null;
    }
  }

  private void HandleError(Exception error)
  {
    Console.WriteLine();
    Console.WriteLine(error.Message);
    Console.Write("\nPress enter to continue. ");
    _input.Ask();
  }

  private void CompletedGoals()
  {
    List<Goal> completedGoals = _goals.Where(goal => !(goal is EternalGoal) ? goal.IsComplete() : true).ToList();
    int xtraPoints = 500;

    if (completedGoals.Count >= 5)
    {
      for (int i = completedGoals.Count; i > 5; i++)
      {
        xtraPoints += 150;
      }

      Console.WriteLine($"Congratulations! You have earned {xtraPoints} points!");
      _score += xtraPoints;
    }
  }
}