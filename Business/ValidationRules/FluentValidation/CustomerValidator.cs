﻿using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {

            RuleFor(c => c.CompanyName).MinimumLength(3);
            RuleFor(c => c.UserId).NotEmpty();

        }
    }


}
