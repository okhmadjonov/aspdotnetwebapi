﻿using System.ComponentModel.DataAnnotations.Schema;

namespace aspdotnetwebapi.Entities
{
    public class Lesson : IEntity
    {
        public Guid Id { get; set; }
        public Guid? CourseId { get; set; }
        [ForeignKey(nameof(CourseId))]
        public Course? Course { get; set; }
        public string? Title { get; set; }
        public List<string>? VideoUrl { get; set; }
        public List<string>? Info { get; set; }
    }
}
