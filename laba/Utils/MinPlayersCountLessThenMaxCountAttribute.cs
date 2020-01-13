using laba.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace laba.Utils
{
    public class MinPlayersCountLessThenMaxCountAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = (QuestRoom)validationContext.ObjectInstance;

            if (model.MinPlayersCount < model.MaxPlayersCount)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Min players count must be less then Max players count");
        }
    }
}