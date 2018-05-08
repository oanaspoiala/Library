using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Library.Domain.Core.Entities;

namespace Library.Domain.Entities
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
        [Display(Name = @"Prenume")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        [Display(Name = @"Nume")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the birth date.
        /// </summary>
        /// <value>
        /// The birth date.
        /// </value>
        [Display(Name = @"Data nașterii")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Gets or sets the death date.
        /// </summary>
        /// <value>
        /// The death date.
        /// </value>
        [Display(Name = @"Data decesului")]
        [DataType(DataType.Date)]
        public DateTime? DeathDate { get; set; }

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
