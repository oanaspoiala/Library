using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Library.Domain.Core.Entities;

namespace Library.Domain.Entities
{
    /// <summary>
    /// BookExemplary
    /// </summary>
    public class BookExemplary : EntityWithId<Guid>
    {
        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the book identifier.
        /// </summary>
        /// <value>
        /// The book identifier.
        /// </value>
        public Guid BookId { get; set; }

        /// <summary>
        /// Gets or sets the book.
        /// </summary>
        /// <value>
        /// The book.
        /// </value>
        [ForeignKey(nameof(BookId))]
        public virtual Book Book { get; set; }

        public virtual ICollection<WearDegree> WearDegrees { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }

        public virtual ICollection<Loan> Loans { get; set; }
    }
}
