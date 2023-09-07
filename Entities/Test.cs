namespace aspdotnetwebapi.Entities
{
    public class Test
    {
        public Guid Id { get; set; }
        public string? QuestionText { get; set; }
        public string? AnswerText { get; set; }
        public List<Choice>? Choices { get; set; }
    }
}
