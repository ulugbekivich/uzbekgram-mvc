using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Uzbekgram.Service.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class UsernameAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null) return new ValidationResult("Username can not be null!");

            Regex regex = new Regex(@"/^[a-zA-Z0-9]+([a-zA-Z0-9](_|-| )[a-zA-Z0-9])*[a-zA-Z0-9]+$/");

            if (regex.Match(value.ToString()!).Success)
                return ValidationResult.Success;

            return new ValidationResult("Enter correct Username!");
        }
    }
}
