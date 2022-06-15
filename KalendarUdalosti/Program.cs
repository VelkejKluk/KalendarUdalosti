using Spectre.Console;
using KalendarUdalosti;
PomocnaTr pomocnaTrida = new PomocnaTr();

//front page
Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine(@" ___    __    __    ____  _  _  ____    __    ____ 
/ __)  /__\  (  )  ( ___)( \( )(  _ \  /__\  (  _\
( (__  /(__)\  )(__  )__)  )  ( )(_) )/(__)\  )  /
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
        pomocnaTrida.AllEvents();
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
        await AnsiConsole.Progress()
        .StartAsync(async ctx =>
        {
            // Define tasks
            var task1 = ctx.AddTask("[blue]Closing the app[/]");

            while (!ctx.IsFinished)
            {
                // Simulate some work
                await Task.Delay(100);

                // Increment
                task1.Increment(1.5);
            }
        });
        Console.Clear();
        Environment.Exit(1);
    }
}