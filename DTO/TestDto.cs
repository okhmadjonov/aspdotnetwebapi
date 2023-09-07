using aspdotnetwebapi.Entities;

namespace aspdotnetwebapi.DTO
{
    public class TestDto
    {
        public string? QuestionText { get; set; }
        public string? AnswerTest { get; set; }
        public List<Choice>? Choices { get; set; }
    }
}
