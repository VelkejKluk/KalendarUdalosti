using Spectre.Console;
using KalendarUdalosti;
PomocnaTr pomocnaTrida = new PomocnaTr();

//front page
Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine(@" ___    __    __    ____  _  _  ____    __    ____ 
/ __)  /__\  (  )  ( ___)( \( )(  _ \  /__\  (  _ \
( (__  /(__)\  )(__  )__)  )  (  )(_) )/(__)\  )  /
\___)(__)(__)(____)(____)(_)\_)(____/(__)(__)(_)\_)                             
");
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

    }
    else if (vyber == "New Event")
    {
        pomocnaTrida.NewEvent();
    }
    else if (vyber == "Close Application")
    {
        Environment.Exit(1);
    }
}