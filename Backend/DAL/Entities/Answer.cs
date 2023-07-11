using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.DAL.Entities
{
    [Table("Answers")]
    public class Answer
    {
        [Key]
        [Column("Id")]
        public Guid Id { get; set; }

        [Column("Text")]
        public string Text { get; set; }

        [Column("IsRightAnswer")]
        public bool IsRightAnswer { get; set; }

        public Question? Question { get; set; }

        [ForeignKey("Question")]
        public Guid QuestionId { get; set; }
    }
}
