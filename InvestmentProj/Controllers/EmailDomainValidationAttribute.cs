using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace InvestmentProj.ViewModels
{
    public class EmailDomainValidationAttribute : ValidationAttribute
    {
        private readonly string[] _allowedDomains;

        public EmailDomainValidationAttribute(params string[] allowedDomains)
        {
            _allowedDomains = allowedDomains;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string email)
            {
                var domain = email.Split('@').LastOrDefault();
                if (_allowedDomains.Contains(domain, StringComparer.OrdinalIgnoreCase))
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult($"Email domain must be one of the following: {string.Join(", ", _allowedDomains)}");
        }
    }
}
