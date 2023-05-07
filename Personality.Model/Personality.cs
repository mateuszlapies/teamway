namespace Personality.Model
{
    public class Personality
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
    }
}
