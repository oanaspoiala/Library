using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Core.Entities
{
    /// <summary>
    /// Gender
    /// </summary>
    /// <seealso cref="Library.Core.Entities.EntityWithId" />
    public class Gender : EntityWithId<Guid>
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the books.
        /// </summary>
        /// <value>
        /// The books.
        /// </value>
        public virtual ICollection<Book> Books { get; set; }
    }
}
