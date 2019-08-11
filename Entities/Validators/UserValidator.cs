using Entities.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities.Validators
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            RuleFor(x => x.Username)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} is Empty")
                .Length(3, 30).WithMessage("Length of {PropertyName} is Invalid");

            RuleFor(x => x.FirstName)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} is Empty")
                .Length(3, 30).WithMessage("Length of {PropertyName} is Invalid")
                .Must(BeAValidName).WithMessage("{PropertyName} contains Invalid Characters");

            RuleFor(x => x.LastName)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .NotEmpty().WithMessage("{PropertyName} is Empty")
               .Length(3, 30).WithMessage("Length of {PropertyName} is Invalid")
               .Must(BeAValidName).WithMessage("{PropertyName} contains Invalid Characters");

            RuleFor(x => x.PhoneNumber)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .NotEmpty().WithMessage("{PropertyName} is Empty")
               .Length(6, 15).WithMessage("Length of {PropertyName} is Invalid")
               .Must(BeAValidNumber).WithMessage("{PropertyName} contains Invalid Characters");

            RuleFor(x => x.Email)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .NotEmpty().WithMessage("{PropertyName} is Empty")
               .Length(6, 30).WithMessage("Length of {PropertyName} is Invalid")
               .EmailAddress().WithMessage("{PropertyName} is Invalid");

            RuleFor(x => x.Gender)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .NotEmpty().WithMessage("{PropertyName} is Empty")
               .Must(BeAValidGender).WithMessage("{PropertyName} is Invalid");

        }

        protected bool BeAValidName(string name)
        {
            name = name.Replace(" ", "");
            name = name.Replace("-", "");
            return name.All(Char.IsLetter);
        }

        protected bool BeAValidNumber(string number)
        {
            number = number.Replace(" ", "");
            number = number.Replace("-", "");
            number = number.Replace("+", "");
            number = number.Replace("/", "");
            return number.All(Char.IsNumber);
        }

        protected bool BeAValidGender(string gender)
        {
            if (gender.ToLower() == "male" || gender.ToLower() == "female")
            {
                return true;
            }
            return false;
        }


    }
}
