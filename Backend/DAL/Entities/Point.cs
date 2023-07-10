namespace Backend.DAL.Entities
{
    public class Point
    {
        public Guid Id { get; set; }

        public float X { get; set; }

        public float Y { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public string? PhotoWay { get; set; }
    }
}
