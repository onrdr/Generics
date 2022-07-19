using Generics_Ex1.Models;

namespace Generics_Ex1.WithoutGenerics
{
    public class OriginalTextFileProcessor
    {
        public static void SavePeople(List<Person> people, string filePath)
        {
            List<string> lines = new()
            {
                // Add a header row
                "FirstName,IsAlive,LastName"
            };

            people.ForEach(p => lines.Add($"{p.FirstName},{p.IsAlive},{p.LastName}"));

            File.WriteAllLines(filePath, lines);
        }

        public static void SaveLogs(List<LogEntry> logs, string filePath)
        {
            List<string> lines = new()
            {
                // Add a header row
                "ErrorCode,Message,TimeOfEvent"
            };

            logs.ForEach(log => lines.Add($"{log.ErrorCode},{log.Message},{log.TimeOfEvent}"));

            File.WriteAllLines(filePath, lines);
        }

        public static List<LogEntry> LoadLogs(string filePath)
        {
            List<LogEntry> output = new();
            LogEntry log;
            var lines = File.ReadAllLines(filePath).ToList();
            // Remove the header row
            lines.RemoveAt(0);

            lines.ForEach(line =>
            {
                var vals = line.Split(',');
                log = new LogEntry
                {
                    ErrorCode = int.Parse(vals[0]),
                    Message = vals[1],
                    TimeOfEvent = DateTime.Parse(vals[2])
                };
                output.Add(log);
            });
            return output;
        }

        public static List<Person> LoadPeople(string filePath)
        {
            List<Person> output = new();
            Person p;
            var lines = File.ReadAllLines(filePath).ToList();
            // Remove the header row
            lines.RemoveAt(0);

            lines.ForEach(line =>
            {
                var vals = line.Split(',');
                p = new Person
                {
                    FirstName = vals[0],
                    IsAlive = bool.Parse(vals[1]),
                    LastName = vals[2]
                }; 
                output.Add(p);
            }); 
            return output;
        }
    }
}
