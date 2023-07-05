namespace Backend.DAL.Entities
{
    public class Advice
    {
        public Guid Id { get; set; }

        public string Text { get; set; }

        public string Description { get; set; }

        public  string Author { get; set; }

        public string AuthorPhotoWay { get; set; }
    }
}
