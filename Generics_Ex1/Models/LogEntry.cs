 
namespace Generics_Ex1.Models
{
    public class LogEntry
    {
        public string Message { get; set; }
        public int ErrorCode { get; set; }
        public DateTime TimeOfEvent { get; set; } = DateTime.UtcNow;
    }
}


