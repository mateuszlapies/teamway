namespace Personality.Model
{
    public class Question
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public List<Answer> Answers { get; set; }
    }
}