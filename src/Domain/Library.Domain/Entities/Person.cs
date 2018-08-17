using System;
using System.Collections.Generic;
using Library.Domain.Core.Entities;

namespace Library.Domain.Entities
{
    /// <summary>
    /// Person
    /// </summary>
    /// <seealso cref="Guid" />
    public class Person : EntityWithId<Guid>
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
        /// Gets or sets the CNP.
        /// </summary>
        /// <value>
        /// The CNP.
        /// </value>
        public string Cnp { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        /// <value>
        /// The phone.
        /// </value>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets the full name.
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
        public string FullName => FirstName + " " + LastName;

        /// <summary>
        /// Gets or sets the loans.
        /// </summary>
        /// <value>
        /// The loans.
        /// </value>
        public virtual ICollection<Loan> Loans { get; set; }

        /// <summary>
        /// Gets or sets the reservations.
        /// </summary>
        /// <value>
        /// The reservations.
        /// </value>
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
