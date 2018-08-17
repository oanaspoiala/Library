using System;
using System.ComponentModel.DataAnnotations.Schema;
using Library.Domain.Core.Entities;

namespace Library.Domain.Entities
{
    public class Reservation : EntityWithId<Guid>
    {
        public Guid BookExemplaryId { get; set; }

        [ForeignKey(nameof(BookExemplaryId))]
        public virtual BookExemplary BookExemplary { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public DateTime ReservationDate { get; set; }

        public Guid PersonId { get; set; }

        [ForeignKey(nameof(PersonId))]
        public virtual Person Person { get; set; }

    }
}
