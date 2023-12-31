﻿namespace aspdotnetwebapi.Entities
{
    public class Course : IEntity
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public string? ImgUrl { get; set; }
    }
}
