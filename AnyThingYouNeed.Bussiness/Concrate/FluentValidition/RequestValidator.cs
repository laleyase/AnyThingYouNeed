using AnyThingYouNeed.Entities.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AnyThingYouNeed.Bussiness.Concrate.FluentValidition
{
    public class RequestValidator:AbstractValidator<Request>
    {
        public RequestValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Name is required!");
            RuleFor(p => p.Surname).NotEmpty().WithMessage("Surename is required!");

            RuleFor(p => p.EMail).NotEmpty().WithMessage("EMail is required!");
            RuleFor(p => p.PhoneNumber).NotEmpty().WithMessage("PhoneNumber is required!");
            RuleFor(p => p.PhoneNumber).Must(NumericControl).WithMessage("Only numeric characters!");


        }
        private bool NumericControl(string arg)
        {
            bool result = false;
            Regex numericControl = new Regex("^(?=.*?[0-9]).{11,}$");
            if (numericControl.IsMatch(arg) == true)
            {
                result = true;
            }
            return result;
        }
    }
}
