using RiddleMaker.Common.EntityConfiguration;
using System.ComponentModel.DataAnnotations;

namespace RiddleMaker.Web.ViewModels
{
    public class AddViewModel
    {
        [MaxLength(ValidationConstants.RiddleLength)]
        public string Riddle { get; set; } = null!;

        [MaxLength(ValidationConstants.AnswerLength)]
        public string Answer { get; set; } = null!;
    }
}
