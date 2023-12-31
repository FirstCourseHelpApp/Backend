﻿namespace Backend.DAL.Entities
{
    public class SubChapter
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string? DocWay { get; set; }

        public int? Order { get; set; }

        public bool IsCompleted { get; set; }

        public Chapter? Chapter { get; set; }

        public Guid ChapterId { get; set; }

    }
}
