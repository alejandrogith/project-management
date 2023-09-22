using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace ProjectManagement.Modules.AuthUser.Application.Dtos
{

    public class ApplicationUserDtoValidations: AbstractValidator<RegisterRequestDto>
    {

        public ApplicationUserDtoValidations()
        {

            RuleFor(s => s.Email).NotNull().WithMessage("Email address is required")
                      .NotEmpty().WithMessage("{ PropertyName} cannot be empty")
                     .EmailAddress().WithMessage("A valid email is required");

            RuleFor(dto => dto.Password)
                .NotEmpty().WithMessage("Password is required.");

        
        }

    }


    public class LoginDtoValidation : AbstractValidator<LoginRequestDto>
    {

        public LoginDtoValidation()
        {

            RuleFor(s => s.Email).NotNull().WithMessage("Email address is required")
                      .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
                     .EmailAddress().WithMessage("A valid email is required"); ;

            RuleFor(dto => dto.Password)
                .NotEmpty().WithMessage("Email address is required")
                 .NotNull().WithMessage("{PropertyName} is required");

        }

    }

}
