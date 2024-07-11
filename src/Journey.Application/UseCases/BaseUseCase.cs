using Journey.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Journey.Application.UseCases
{
    public abstract class BaseUseCase
    {
        protected readonly AppDbContext _context;
        public BaseUseCase()
        {
            _context = new AppDbContext();
        }

        

    }
}
