using FluentValidation.Results;
using Journey.Communication.Requests;
using Journey.Communication.Responses;
using Journey.Core.Entities;
using Journey.Exception;
using Journey.Exception.ExceptionsBase;
using Microsoft.EntityFrameworkCore;

namespace Journey.Application.UseCases.Trips.Activities.RegisterActivity
{
    public class RegisterActivityUseCase : BaseUseCase
    {
        public async Task<ResponseActivityJson> Execute(Guid tripId, RequestRegisterActivityJson request)
        {

            var trip = await _context.Trips.FirstOrDefaultAsync(t => t.Id == tripId);

            if (trip is null)
            {
                throw new NotFoundException(ResourceErrorMessages.NOT_FOUND_OBJECT);
            }

            Validate(request, trip);
            var entityActivity = new Activity { Name = request.Name, Date = request.Date, TripId = tripId };
            _context.Activities.Add(entityActivity);
            await _context.SaveChangesAsync();

            return new ResponseActivityJson { Name = entityActivity.Name, Date = entityActivity.Date, Id = entityActivity.Id, Status = entityActivity.Status };
        }

        public void Validate(RequestRegisterActivityJson request, Trip trip)
        {
            var validator = new RegisterActivityValidator();
            var result = validator.Validate(request);

            if ((request.Date >= trip.StartDate && request.Date <= trip.EndDate) is false)
            {
                result.Errors.Add(new ValidationFailure("Date", ResourceErrorMessages.DATE_ACTIVITY_MUST_BETWEEN_END_START_DATE));
            }

            if (result.IsValid is false)
            {
                var errors = result.Errors.Select(s => s.ErrorMessage).ToList();
                throw new OnValidationException(errors);
            }


        }
    }
}
