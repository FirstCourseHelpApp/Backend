﻿namespace Backend.DAL.Entities
{
    public class Chapter
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public double? SuccessRate { get; set; }

        public int? Order { get; set; }

        public ICollection<SubChapter> SubChapters { get; set; } = new List<SubChapter>();

        public Test Test { get; set; }
    }
}
