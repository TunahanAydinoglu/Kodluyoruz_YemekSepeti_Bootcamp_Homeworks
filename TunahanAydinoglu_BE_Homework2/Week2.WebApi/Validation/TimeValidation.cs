using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Week2.WebApi.Data.Dto;
using Week2.WebApi.Data.Entity;

namespace Week2.WebApi.Validation
{
    public class TimeValidation : ValidationAbstract
    {
        private LessonDto _request;

        public TimeValidation(LessonDto request)
        {
            _request = request;
        }

        public override bool IsValidTime(List<ValidationResult> validationResult)
        {
                var context = new ValidationContext(_request);
                bool isValid = Validator.TryValidateObject(_request, context, validationResult, true);
                return isValid;
        }
    }
}
