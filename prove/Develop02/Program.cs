using System;

/**
    User Interface Abstraction succesfully applied ✔ :

    - UserInterface class manage general functionality like display and dispatch actions.
    - WriteEntryUI class to isolate write entry process.
    - ManageFilesUI class to control saving and loading process.
    - UserInput class to control entered data and retriving it again.
*/

class Program
{
    static DateTime _date = DateTime.Now;
    static Journal _myJournal = new Journal();

    static void Main(string[] args)
    {
        // bool exit = false;
        // UserInput input = new UserInput();

        List<string> options = new List<string>() { "Write", "Display", "Load", "Save", "Quit" };
        List<string> prompts = new List<string>() {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        UserInterface programUi = new UserInterface(_date, _myJournal, options, prompts);

        // WriteEntryUI writeUi = new WriteEntryUI(_date, _myJournal, prompts);
        // ManageFilesUI fileAdmin = new ManageFilesUI(_myJournal);

        do
        {
            programUi.DisplayActions();

            // Console.WriteLine("Please select one of the following actions: \n");

            // for (int i = 0; i < options.Count; i++)
            // {
            //     Console.WriteLine($"{i + 1}. {options[i]}");
            // }

            Console.WriteLine();

            programUi.CatchingAction();

            // Console.Write("What would you like to do? ");
            // input.Ask();

            Console.WriteLine();

            programUi.Action();

            // int action = int.Parse(input.GetInputText());

            // switch (action)
            // {
            //     case 1:
            //         writeUi.WriteEntry();
            //         break;
            //     case 2:
            //         _myJournal.DisplayAll();
            //         break;
            //     case 3:
            //         fileAdmin.Load();
            //         break;
            //     case 4:
            //         fileAdmin.Save();
            //         break;
            //     case 5:
            //         exit = !exit;
            //         break;
            //     default:
            //         Console.WriteLine("Sorry. Action not found.");
            //         break;
            // }

            // if (action != 5)
            // {
            //     Console.Write("Press enter to continue...");
            //     Console.ReadLine();
            // }
            // else
            // {
            //     Console.WriteLine("Thanks for use our app!");
            // }

            Console.WriteLine();
        } while (!programUi._Exit);
    }
}