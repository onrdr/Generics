
using Generics_Ex1.Models;

namespace Generics_Ex1.WithGenerics
{
    internal class GenericProgram
    {
        internal static void DemonstrateTextFileStorage()
        {
            List<Person> people = new();
            List<LogEntry> logs = new();

            string peopleFile = @"C:\Users\onrdr\source\repos\Generics\Generics_Ex1\people.csv";
            string logFile = @"C:\Users\onrdr\source\repos\Generics\Generics_Ex1\logs.csv";

            PopulateLists(people, logs);

            // OriginalTextFileProcessor.SaveLogs(logs, logFile);
            //var newLogs = OriginalTextFileProcessor.LoadLogs(logFile);
            //newLogs.ForEach(log => Console.WriteLine($"{log.ErrorCode}: \t{log.Message} \tat {log.TimeOfEvent.ToShortTimeString()}"));

            //OriginalTextFileProcessor.SavePeople(people, peopleFile);
            //var newPeople = OriginalTextFileProcessor.LoadPeople(peopleFile);
            //newPeople.ForEach(p => Console.WriteLine($"{p.FirstName} {p.LastName} (Is Alive : {p.IsAlive})"));
        }

        static void PopulateLists(List<Person> people, List<LogEntry> logs)
        {
            people.Add(new Person { FirstName = "Onur", LastName = "Derman" });
            people.Add(new Person { FirstName = "Kobe", LastName = "Bryant", IsAlive = false });
            people.Add(new Person { FirstName = "Allen", LastName = "Iverson" });

            logs.Add(new LogEntry { Message = "My three points shot failed", ErrorCode = 2222 });
            logs.Add(new LogEntry { Message = "He was too great but died :(", ErrorCode = 1111 });
            logs.Add(new LogEntry { Message = "He like crossovers but retired", ErrorCode = 3333 });

        }
    }
}
