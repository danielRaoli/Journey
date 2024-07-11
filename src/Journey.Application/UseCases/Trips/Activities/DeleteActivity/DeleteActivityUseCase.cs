using Journey.Exception.ExceptionsBase;
using Journey.Exception;
using Microsoft.EntityFrameworkCore;

namespace Journey.Application.UseCases.Trips.Activities.DeleteActivity
{
    public class DeleteActivityUseCase : BaseUseCase
    {
        public async Task Execute(Guid tripId, Guid activityId)
        {
            var activity = await _context.Activities.FirstOrDefaultAsync(a => a.Id == activityId && a.TripId == tripId);

            if (activity is null)
            {
                throw new NotFoundException(ResourceErrorMessages.NOT_FOUND_OBJECT);
            }

            _context.Activities.Remove(activity);
            await _context.SaveChangesAsync();

        }
    }
}
