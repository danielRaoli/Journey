using Journey.Core.Enums;
using Journey.Exception;
using Journey.Exception.ExceptionsBase;
using Microsoft.EntityFrameworkCore;

namespace Journey.Application.UseCases.Trips.Activities.UpdateActivity
{
    public class UpdateActivityStatusUseCase : BaseUseCase
    {
        public async Task Execute(Guid tripId, Guid activityId)
        {
            var activity = await _context.Activities.FirstOrDefaultAsync(a => a.Id == activityId && a.TripId == tripId);

            if (activity is null)
            {
                throw new NotFoundException(ResourceErrorMessages.NOT_FOUND_OBJECT);
            }

            activity.Status = ActivityStatus.Done;
            _context.Update(activity);
            await _context.SaveChangesAsync();  

        }
    }
}
