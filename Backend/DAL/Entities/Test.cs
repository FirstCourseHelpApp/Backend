﻿namespace Backend.DAL.Entities
{
    public class Test
    {
        public Guid Id { get; set; }

        public int? Order { get; set; }
        
        public int? MaxScore { get; set; }

        public Chapter? Chapter { get; set; }

        public Guid ChapterId { get; set; }

        public ICollection<Question> Questions { get; set; } = new List<Question>();
    }
}
