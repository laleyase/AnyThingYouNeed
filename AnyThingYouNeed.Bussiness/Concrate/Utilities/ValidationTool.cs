using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyThingYouNeed.Bussiness.Concrate.Utilities
{
    public class ValidationTool
    {
        public static void Validate<T>(AbstractValidator<T> validator, T entity)
        {
            var result = validator.Validate(entity);
            if (result.Errors.Count > 0)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
