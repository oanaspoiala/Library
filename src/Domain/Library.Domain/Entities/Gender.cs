using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Library.Domain.Core.Entities;

namespace Library.Domain.Entities
{
    /// <summary>
    /// Gender
    /// </summary>
    /// <seealso cref="EntityWithId{TId}" />
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
