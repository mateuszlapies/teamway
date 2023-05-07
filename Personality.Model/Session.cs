namespace Personality.Model
{
    public class Session
    {
        public long Id { get; set; }
        public IList<Selection> Selections { get; set; }
    }
}
