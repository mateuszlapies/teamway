namespace Personality.Model
{
    public class Selection
    {
        public long Id { get; set; }
        public long AnswerId { get; set; }
        public Answer Answer { get; set; }
        public Session Session { get; set; }
    }
}
