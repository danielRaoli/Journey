using Journey.Communication.Requests;
using Journey.Communication.Responses;
using Journey.Core.Entities;
using Journey.Exception.ExceptionsBase;
using Journey.Infrastructure.Persistence;

namespace Journey.Application.UseCases.Trips.Register
{
    public class RegisterTripUseCase
    {
        public async Task<ResponseShortTripJson> Execute(RequestRegisterTripJson request)
        {
            Validate(request);

            var context = new AppDbContext();

            var trip = new Trip
            {
                Name = request.Name,
                StartDate = request.StartDate,
                EndDate = request.EndDate
            };

            context.Trips.Add(trip);

            await context.SaveChangesAsync();

            return new ResponseShortTripJson
            {
                Name = request.Name,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Id = trip.Id
            };

        }

        public void Validate(RequestRegisterTripJson request)
        {
            var validator = new RegisterTripValidator();

            var result = validator.Validate(request);

            if(result.IsValid is false)
            {
                var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

                throw new OnValidationException(errorMessages);
            }
        }
    }


}
