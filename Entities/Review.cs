﻿using System.ComponentModel.DataAnnotations.Schema;

namespace aspdotnetwebapi.Entities
{
    public class Review : IEntity
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public string? Name { get; set; }
        public Guid? DescriptionCourseId { get; set; }
        [ForeignKey(nameof(DescriptionCourseId))]
        public DescCourse? DescriptionCourse { get; set; }

    }
}
