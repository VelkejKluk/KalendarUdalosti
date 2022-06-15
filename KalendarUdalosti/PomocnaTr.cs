using Spectre.Console;

namespace KalendarUdalosti
{
    internal class PomocnaTr
    {
        List<DateOnly> data = new List<DateOnly>();

        public void ActualMonth()
        {
            //nacte soucasny datum
            DateOnly soucasnyDatum = DateOnly.FromDateTime(DateTime.Now);

            //oznací cervene v kalendari
            var calendar = new Calendar(soucasnyDatum.Year, soucasnyDatum.Month);
            calendar.AddCalendarEvent(soucasnyDatum.Year, soucasnyDatum.Month, soucasnyDatum.Day);
            AnsiConsole.Write(calendar.HighlightStyle(Style.Parse("red bold")));

        }

        public void AllEvents()
        {
            //ověření, jestli je prázdný List nebo ne
            DateTime zkouska = new DateTime();
            foreach (DateOnly date in this.data)
            {
                zkouska = date.ToDateTime(TimeOnly.Parse("00:00 AM"));
            }  
                        
            if (zkouska != DateTime.MinValue)
            {
                //vyber z DateonlyListu - potreba prevest na DateTime, jinak nejde vybrat
                var vyber = AnsiConsole.Prompt(new SelectionPrompt<DateTime>()
                    .Title("Events:")
                    .PageSize(10)
                    .AddChoices(this.data.Select(x => x.ToDateTime(TimeOnly.Parse("00:00 AM"))))
                );

                Calendar calendar = new Calendar(vyber);
                calendar.AddCalendarEvent(vyber);
                //barvicky
                AnsiConsole.Write(calendar.HighlightStyle(Style.Parse("yellow bold")));
                Console.ReadKey();
            }
            else
            {
                this.Helper();
            }
            
        }

        public void NewEvent()
        {
            while (true)
            {
                //nacitani roku, mesice, dne
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

                //vytvori novy dateonly a prida to do Listu 'data'
                DateOnly date = new DateOnly(year, month, day);
                data.Add(date);
                break;
            }
        }

        public void DeleteAll()
        {

        }

        public void Helper()
        {
            //vypise cervene error a bude trvat 3s
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("error");
            Console.ResetColor();
            Thread.Sleep(300);
        }
    }
}