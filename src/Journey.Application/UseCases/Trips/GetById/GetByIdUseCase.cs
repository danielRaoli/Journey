using Journey.Communication.Responses;
using Journey.Exception;
using Journey.Exception.ExceptionsBase;
using Microsoft.EntityFrameworkCore;

namespace Journey.Application.UseCases.Trips.GetById
{
    public class GetByIdUseCase : BaseUseCase
    {
        public async Task<ResponseTripJson> Execute(Guid id)
        {
           

            var trip = await _context.Trips.Include(t => t.Activities).FirstOrDefaultAsync(t => t.Id == id);

            if (trip == null) throw new NotFoundException(ResourceErrorMessages.NOT_FOUND_OBJECT);

            return new ResponseTripJson
            {
                Name = trip.Name,
                StartDate = trip.StartDate,
                EndDate = trip.EndDate,
                Id = trip.Id,
                Activities = trip.Activities.Select(a => new ResponseActivityJson { Id = a.Id, Name = a.Name, Date = a.Date, Status = a.Status }).ToList()
            };
        }
    }
}
