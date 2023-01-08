using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidImpact.Framework.Validators {
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class RequiredWithAttribute : ValidationAttribute {
        public string PropertyName { get; }

        public RequiredWithAttribute(string propertyName) {
            PropertyName = propertyName;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext) {
            if (value == null) return ValidationResult.Success;

            var property = validationContext.ObjectType.GetProperty(PropertyName);
            if (property != null) {
                object? otherValue = property.GetValue(validationContext.ObjectInstance);
                if (otherValue == null) return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
