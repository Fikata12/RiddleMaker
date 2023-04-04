using System.ComponentModel.DataAnnotations;

using RiddleMaker.Common;

namespace RiddleMaker.Web.ViewModels
{
    public class AddRiddleViewModel
    {
        [Required]
        [MaxLength(ViewModelsValidation.RiddleLength)]
        public string Riddle { get; set; } = null!;

        [Required]
        [MaxLength(ViewModelsValidation.AnswerLength)]
        public string Answer { get; set; } = null!;
    }
}
