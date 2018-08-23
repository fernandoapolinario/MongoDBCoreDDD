using FluentValidation;
using MongoDBCoreDDD.CrossCutting;
using MongoDBCoreDDD.Domain.Entities;
using System;

namespace MongoDBCoreDDD.Service.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(c => c)
                    .NotNull()
                    .OnAnyFailure(x =>
                    {
                        throw new ArgumentNullException("Can't found the object.");
                    });

            RuleFor(c => c.FistName)
                .NotEmpty().WithMessage("Is necessary to inform the Fist Name.")
                .NotNull().WithMessage("Is necessary to inform the Fist Name.");

            RuleFor(c => c.LastName)
                .NotEmpty().WithMessage("Is necessary to inform the Last Name.")
                .NotNull().WithMessage("Is necessary to inform the Last Name.");

            RuleFor(c => c.Age)
                .GreaterThanOrEqualTo(18).WithMessage("You must have more than 18 years old.");

            RuleFor(x => x.Document).Must(CpfValidation.IsCPF).WithMessage("Please specify a valid document");
        }
    }
}
