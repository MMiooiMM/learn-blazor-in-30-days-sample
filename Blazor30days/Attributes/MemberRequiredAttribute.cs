using System.ComponentModel.DataAnnotations;
using Blazor30days.Enums;
using Blazor30days.Model;

namespace Blazor30days.Attributes
{
    public class MemberRequiredAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var user = (UserViewModel)validationContext.ObjectInstance;

            if (user.UserType == UserType.member && (value is null || string.IsNullOrEmpty(value.ToString())))
            {
                return new ValidationResult(base.ErrorMessage ?? "此欄位會員必填！", new[] { validationContext.MemberName });
            }

            return ValidationResult.Success;
        }
    }
}