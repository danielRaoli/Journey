using Journey.Exception;
using Journey.Exception.ExceptionsBase;
using Journey.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Journey.Application.UseCases.Trips.Delete
{
    public  class DeleteTripUseCase : BaseUseCase
    {

        public async Task Execute(Guid id)
        {
           
            var trip = await _context.Trips.FirstOrDefaultAsync(t => t.Id == id);
            if (trip == null)
            {
                throw new NotFoundException(ResourceErrorMessages.NOT_FOUND_OBJECT);
            }

            _context.Trips.Remove(trip);
            await _context.SaveChangesAsync();   

        }

    }
}
