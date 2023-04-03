﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using RiddleMaker.Common.EntityConfiguration;

namespace RiddleMaker.Data.Models
{
    public class Riddle
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(ValidationConstants.RiddleLength)]
        public string Text { get; set; } = null!;

        [ForeignKey("Answer")]
        public int AnswerId { get; set; }

        public virtual Answer Answer { get; set; } = null!;
    }
}