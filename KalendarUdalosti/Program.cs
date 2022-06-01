using Spectre.Console;
using KalendarUdalosti;
PomocnaTr pomocnaTrida = new PomocnaTr();

//front page
Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine(@" ___    __    __    ____  _  _  ____    __    ____ 
/ __)  /__\  (  )  ( ___)( \( )(  _ \  /__\  (  _ \
( (__  /(__)\  )(__  )__)  )  (  )(_) )/(__)\  )  /
\___)(__)(__)(____)(____)(_)\_)(____/(__)(__)(_)\_)                             
");
Console.ResetColor();
Thread.Sleep(5000);
Console.Clear();

while (true)
{
    var vyber = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
        .Title("Menu:")
        .PageSize(10)
        .AddChoices(new[] {
    "Calendar", "All Events", "New Event",
    "Close Application",
        }));
    if (vyber == "Calendar")
    {
        pomocnaTrida.ActualMonth();
        Console.ReadKey();
        Console.Clear();
    }
    else if (vyber == "All Events")
    {
        DateTime working = new DateTime();
        pomocnaTrida.AllEvents(working);
        Console.ReadKey();
        Console.Clear();
    }
    else if (vyber == "New Event")
    {
        pomocnaTrida.NewEvent();
        Console.Clear();
    }
    else if (vyber == "Close Application")
    {
        Environment.Exit(1);
    }
}