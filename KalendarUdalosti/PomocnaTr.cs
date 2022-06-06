using Spectre.Console;

namespace KalendarUdalosti{
    internal class PomocnaTr{
        List<DateOnly> data = new List<DateOnly>();
        

        public void ActualMonth()
        {
            DateOnly soucasnyDatum = DateOnly.FromDateTime(DateTime.Now);

            var calendar = new Calendar(soucasnyDatum.Year, soucasnyDatum.Month);
            calendar.AddCalendarEvent(soucasnyDatum.Year, soucasnyDatum.Month, soucasnyDatum.Day);
            AnsiConsole.Write(calendar.HighlightStyle(Style.Parse("red bold")));
        }

        public void AllEvents(DateTime dateTime)
        {
            foreach (DateOnly date in this.data)
            {
                dateTime = date.ToDateTime(TimeOnly.Parse("00:00 AM"));

                var datum = new Calendar(dateTime);
                datum.AddCalendarEvent(dateTime.Year, dateTime.Month, dateTime.Day);
                //datum.HighlightStyle(Style.Parse("green bold"));
            }
            while (true)
            {
                if (dateTime != DateTime.MinValue)
                {
                    var vyber = AnsiConsole.Prompt(
                    new SelectionPrompt<DateTime>()
                    .Title("Events:")
                    .PageSize(10)
                    .AddChoices(new[] { dateTime }));
                    var calendar = new Calendar(vyber);
                    calendar.AddCalendarEvent(vyber);
                    AnsiConsole.Write(calendar.HighlightStyle(Style.Parse("yellow bold")));
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("error");
                    Console.ResetColor();
                    break;
                }
                
            }
        }

        public void NewEvent()
        {
            while (true)
            {
                Console.Write("year: ");
                int year = Convert.ToInt32(Console.ReadLine());
                if (year >= 1950 && year <= 2022) { }
                else
                {
                    this.Helper();
                    break;
                }
                Console.Write("month: ");
                int month = Convert.ToInt32(Console.ReadLine());
                if (month >= 1 && month <= 12) { }
                else
                {
                    this.Helper();
                    break;
                }
                Console.Write("day: ");
                int day = Convert.ToInt32(Console.ReadLine());
                if (day >= 1 && day <= 31) { }
                else
                {
                    this.Helper();
                    break;
                }

                DateOnly date = new DateOnly(year, month, day);
                data.Add(date);
                break;
            }
        }

        public void Helper()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("error");
            Console.ResetColor();
            Thread.Sleep(300);
        }
    }
}