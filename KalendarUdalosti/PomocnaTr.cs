using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace KalendarUdalosti
{
    internal class PomocnaTr
    {
        
        public void ActualMonth()
        {
            DateOnly soucasnyDatum = DateOnly.FromDateTime(DateTime.Now);

            var calendar = new Calendar(soucasnyDatum.Year, soucasnyDatum.Month);
            AnsiConsole.Write(calendar);
        }
        public void AllEvents()
        {
            var vyber = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Menu:")
                .PageSize(10)
                .AddChoices(new[] {
                "Calendar", "All Events", "New Event",
                "Close Application",
            }));
        }
        public void NewEvent()
        {
            Console.Write("year: ");
            int year = Convert.ToInt32(Console.ReadLine());
            Console.Write("month: ");
            int month = Convert.ToInt32(Console.ReadLine());
            Console.Write("day: ");

            int day = Convert.ToInt32(Console.ReadLine());
            List<DateOnly> events = new List<DateOnly>();
            var calendar = new Calendar(year, month);
            calendar.AddCalendarEvent(year, month, day);
            calendar.HighlightStyle(Style.Parse("green bold"));
            AnsiConsole.Write(calendar);
        }
    }
}
