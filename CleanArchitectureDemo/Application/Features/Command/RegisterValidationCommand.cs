using Application.Interface.IRepository;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Command
{
    public class RegisterValidationCommand : AbstractValidator<CreateRegisterCommand>
    {
        private readonly IRegisterRepo _registerRepo;

        public RegisterValidationCommand(IRegisterRepo registerRepo)
        {
            _registerRepo = registerRepo;

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
            //.MustAsync(IsUniqueBarcode).WithMessage("{PropertyName} already exists.");

            RuleFor(p => p.UserName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
        }

        //private async Task<bool> IsUniqueEmail(string Email, string UserName CancellationToken cancellationToken)
        //{
        //    return await _registerRepo .IsUniqueUser(Email, UserName);
        //}
    }
}
