using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Core.Entities
{
    /// <summary>
    /// Loan
    /// </summary>
    public class Loan : EntityWithId<Guid>
    {
        /// <summary>
        /// Gets or sets the book identifier.
        /// </summary>
        /// <value>
        /// The book identifier.
        /// </value>
        public Guid BookExemplaryId { get; set; }

        /// <summary>
        /// Gets or sets the book.
        /// </summary>
        /// <value>
        /// The book.
        /// </value>
        [ForeignKey("BookExemplaryId")]
        public virtual BookExemplary BookExemplary { get; set; }

        /// <summary>
        /// Gets or sets the person identifier.
        /// </summary>
        /// <value>
        /// The person identifier.
        /// </value>
        public Guid PersonId { get; set; }

        /// <summary>
        /// Gets or sets the person.
        /// </summary>
        /// <value>
        /// The person.
        /// </value>
        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }

        /// <summary>
        /// Gets or sets from date.
        /// </summary>
        /// <value>
        /// From date.
        /// </value>
        [Required]
        public DateTime FromDate { get; set; }

        /// <summary>
        /// Gets or sets to date.
        /// </summary>
        /// <value>
        /// To date.
        /// </value>
        [Required]
        public DateTime ToDate { get; set; }

        /// <summary>
        /// Gets or sets the return date.
        /// </summary>
        /// <value>
        /// The return date.
        /// </value>
        public DateTime? ReturnDate { get; set; }
    }
}
