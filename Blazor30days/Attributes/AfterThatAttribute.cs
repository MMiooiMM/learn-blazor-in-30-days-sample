using System;
using System.ComponentModel.DataAnnotations;

namespace Blazor30days.Attributes
{
    public class AfterThatAttribute : CompareAttribute
    {
        private readonly string _startDatePropertyName;

        public AfterThatAttribute(string startTimePropertyName) : base(startTimePropertyName)
        {
            _startDatePropertyName = startTimePropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var startDatePropertyInfo = validationContext.ObjectType.GetProperty(_startDatePropertyName);

                var startDate = startDatePropertyInfo.GetValue(validationContext.ObjectInstance, null);

                if (DateTime.Compare((DateTime)startDate, (DateTime)value) >= 0)
                    return new ValidationResult("結束時間需在開始時間之後！", new[] { validationContext.MemberName, _startDatePropertyName });
            }

            return ValidationResult.Success;
        }
    }
}