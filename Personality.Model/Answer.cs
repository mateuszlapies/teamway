namespace Personality.Model
{
    public class Answer
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public int Value { get; set; }
        public long QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
