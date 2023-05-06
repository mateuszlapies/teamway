namespace Personality.Data
{
    public class QuestionDto
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public IEnumerable<AnswerDto> Answers { get; set; }
    }
}
