namespace Backend.DAL.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }
        
        public UserProgress? UserProgress { get; set; }
    }
}
