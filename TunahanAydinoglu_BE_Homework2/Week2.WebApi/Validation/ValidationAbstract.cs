using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Week2.WebApi.Data.Dto;

namespace Week2.WebApi.Validation
{
    public abstract class ValidationAbstract
    {
        public abstract bool IsValidTime(List<ValidationResult> validationResult);
    }
}
