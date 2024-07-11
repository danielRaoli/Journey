using Journey.Communication.Responses;
using Journey.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Journey.Application.UseCases.Trips.GetAll
{
    public class GetAllTripsUseCase : BaseUseCase
    {
        public async Task<ResponseTripsJson> Execute()
        { 

            var trips = await _context.Trips.ToListAsync();

            return new ResponseTripsJson
            {
                Trips = trips.Select(trip => new ResponseShortTripJson { Id = trip.Id, Name = trip.Name, EndDate = trip.EndDate, StartDate = trip.StartDate }).ToList()
            };
        }
    }
}
