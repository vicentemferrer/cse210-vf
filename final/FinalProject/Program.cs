using System;

class Program
{
    static async Task Main(string[] args)
    {
        Application app = new Application();
        await app.Start();
    }
}