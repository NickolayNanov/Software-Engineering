namespace BillsPaymentSystem.Models.Attributes
{
    using System;
    using System.ComponentModel.DataAnnotations;

    [AttributeUsage(AttributeTargets.Property)]
    public class ExprirationDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var currentDatetime = DateTime.Now;
            var targetDateTime = (DateTime)value;

            if(currentDatetime > targetDateTime)
            {
                return new ValidationResult("The card has expired!");
            }

            return ValidationResult.Success;
        }
    }
}
