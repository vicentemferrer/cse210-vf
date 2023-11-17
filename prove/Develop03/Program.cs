using System;

class Program
{
    /*
        Verse class added to ease manipulation of multiple verses scriptures (it works for one verse scriptures) ✔
        I worked with HTTP requests to automatize scripture text obtention:
            - ScriptureRequest class added to manage HTTP requests by receiving the Reference instance ✔
            - RequestModel, ApiInfo and ScriptureModel classes were added to parse obtained data ✔
        UserInput class is used to ease Console.ReadLine management ✔ (UI component reused from last week hahahahaha)
    */

    private static Random _logic = new Random();
    private static UserInput _input = new UserInput();
    static async Task Main(string[] args)
    {
        bool mightContinue = true;

        Reference reference = new Reference("Mosiah", 2, 17, 20);

        ScriptureRequest request = new ScriptureRequest(reference);
        await request.Request();

        string text = request.GetScriptureText();

        Scripture scripture = new Scripture(reference, text);

        do
        {
            mightContinue = !scripture.IsCompletelyHidden();

            Console.Clear();

            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.Write("Press enter to continue or type \'quit\' to finish: ");
            _input.Ask();

            if (_input.GetInputText() == "") scripture.HideRandomWords(_logic, _logic.Next(5, 10));

        } while (_input.GetInputText() != "quit" && mightContinue);
    }
}