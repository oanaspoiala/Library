using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Library.Core.Entities
{
    /// <summary>
    /// BookExemplary
    /// </summary>
    /// <seealso cref="Library.Core.Entities.EntityWithId" />
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
        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }

        /// <summary>
        /// Gets or sets the loans.
        /// </summary>
        /// <value>
        /// The loans.
        /// </value>
        public virtual Person Loans { get; set; }
    }
}
