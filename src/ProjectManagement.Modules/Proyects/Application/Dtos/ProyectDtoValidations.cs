using FluentValidation;

namespace ProjectManagement.Modules.Proyects.Application.Dtos
{
    public class ProyectResponseDtoValidator : AbstractValidator<ProyectResponseDto>
    {
        public ProyectResponseDtoValidator()
        {
            RuleFor(dto => dto.Id)
                .NotEmpty().WithMessage("Id is required.");

            RuleFor(dto => dto.Nombre)
                .NotEmpty().WithMessage("Nombre is required.")
                .MaximumLength(100).WithMessage("Nombre cannot exceed 100 characters.");

            RuleFor(dto => dto.Descripcion)
                .NotEmpty().WithMessage("Descripcion is required.")
                .MaximumLength(500).WithMessage("Descripcion cannot exceed 500 characters.");




        }
    }





}
