using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uzbekgram.Service.Common.Attributes
{
    public class StrongPasswordAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null) return new ValidationResult("Parol majburiy!!");
            else
            {
                string password = value.ToString()!;
                if (password.Length < 8)
                    return new ValidationResult("Parol eng kamida 8 ta belgidan iborat bo'lishi kerak!");
                else if (password.Length > 50)
                    return new ValidationResult("Parol 50 ta belgidan kam bo'lishi kerak!");
                var result = IsStrong(password);

                if (result.IsValid is false) return new ValidationResult(result.Message);
                return ValidationResult.Success;
            }
        }

        public (bool IsValid, string Message) IsStrong(string password)
        {
            bool isDigit = password.Any(x => char.IsDigit(x));
            bool isLower = password.Any(x => char.IsLower(x));
            bool isUpper = password.Any(x => char.IsUpper(x));
            if (!isLower)
                return (IsValid: false, Message: "Parolda hech bo'lmaganda 1 ta kichik harf bo'lishi kerak!");
            if (!isUpper)
                return (IsValid: false, Message: "Parolda hech bo'lmaganda 1 ta katta harf bo'lishi kerak!");
            if (!isDigit)
                return (IsValid: false, Message: "Parolda hech bo'lmaganda 1 ta raqam bo'lishi kerak!");

            return (IsValid: true, Message: "Kuchli parol!");
        }
    }
}
