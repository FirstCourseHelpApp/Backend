namespace Backend.DAL.Entities
{
    public class UserProgress
    {
        public Guid Id { get; set; }



        public User User { get; set; }

        public Guid UserId { get; set; }
    }
}
