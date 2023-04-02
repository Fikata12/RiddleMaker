using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RiddleMaker.Common.EntityConfiguration;

namespace RiddleMaker.Data.Models
{
    public class Answer
    {
        public Answer()
        {
            Riddles = new HashSet<Riddle>();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(ValidationConstants.AnswerLength)]
        public string Text { get; set; } = null!;

        public virtual ICollection<Riddle> Riddles { get; set; } = null!;
    }
}