namespace Backend.DAL.Entities
{
    public class Article
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Theme { get; set; }

        public string DocWay { get; set; }
    }
}
