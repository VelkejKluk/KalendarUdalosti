using Spectre.Console;

Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine(@"  ___    __    __    ____  _  _  ____    __    ____ 
/ __)  /__\  (  )  ( ___)( \( )(  _ \  /__\  (  _ \
( (__  /(__)\  )(__  )__)  )  (  )(_) )/(__)\  )   /
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
    if (vyber == "Kalendář aktuálního měsíce")
    {
        DateOnly soucasnyDatum = DateOnly.FromDateTime(DateTime.Now);
        
        var calendar = new Calendar(soucasnyDatum.Year, soucasnyDatum.Month);
        calendar.Culture("cs-CZ");
        AnsiConsole.Write(calendar);
        break;
    }
    else if (vyber == "Zobrazení událostí")
    {

    }
    else if(vyber == "Přidání událostí")
    {

    }
    else if( vyber == "Ukončit aplikaci")
    {
        Environment.Exit(1);
    }
}

