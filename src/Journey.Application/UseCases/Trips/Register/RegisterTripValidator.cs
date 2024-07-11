using FluentValidation;
using Journey.Communication.Requests;
using Journey.Exception;

namespace Journey.Application.UseCases.Trips.Register
{
    public class RegisterTripValidator : AbstractValidator<RequestRegisterTripJson>
    {

        public RegisterTripValidator()
        {
            RuleFor(request => request.Name).NotEmpty().WithMessage(ResourceErrorMessages.NAME_IS_NULL_EMPTY);

            RuleFor(request => request.StartDate.Date).GreaterThanOrEqualTo(DateTime.UtcNow).WithMessage(ResourceErrorMessages.DATES_MUST_BE_lARGER_CURRENT_DATE);

            RuleFor(request => request).Must(request => request.EndDate.Date >= request.StartDate.Date).WithMessage(ResourceErrorMessages.END_DATE_MUST_BE_START_DATE);
        }
    }
}
