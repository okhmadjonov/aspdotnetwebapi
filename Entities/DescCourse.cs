using System.ComponentModel.DataAnnotations.Schema;

namespace aspdotnetwebapi.Entities
{
    public class DescCourse : IEntity
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Review { get; set; }
        public Guid? CourseId { get; set; }
        [ForeignKey(nameof(CourseId))]
        public Course? Course { get; set; }
    }
}
