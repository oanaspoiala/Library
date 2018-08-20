using System;
using System.Threading.Tasks;
using Library.Domain.Entities;
using Library.Persistence.Context;
using Library.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace Library.Repositories.QueryRepository
{
    public abstract class ReservationsQueryRepository : RepositoryBase<Reservation, Guid>
    {
        protected ReservationsQueryRepository(LibraryDbContext context) : base(context)
        {
        }

        public async Task<Reservation> GetById(Guid id)
        {
            return await Context.Reservations
                .Include(x => x.BookExemplary)
                .Include(x => x.Person)
                .Include(x => x.FromDate)
                .Include(x => x.ToDate)
                .Include(x => x.ReservationDate)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
