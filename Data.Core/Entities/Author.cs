using System;
using System.Collections.Generic;

namespace Library.Core.Entities
{
    /// <summary>
    /// Author
    /// </summary>
    /// <seealso cref="Guid" />
    /// <seealso />
    public class Author : EntityWithId<Guid>
    {
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets the full name.
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
        public string FullName => FirstName + " " + LastName;

        /// <summary>
        /// Gets or sets the books.
        /// </summary>
        /// <value>
        /// The books.
        /// </value>
        public virtual ICollection<Book> Books { get; set; }
    }
}
