using System;
using System.Collections.Generic;
using System.Linq;
using Library.Domain.Entities;

namespace Library.Persistence.Context
{
    public class LibraryDbSeeder
    {
        public static void Seed(LibraryDbContext apContext)
        {
            apContext.Database.EnsureCreated();
            if (apContext.Authors.Any())
            {
                return;
            }

            var authors = new List<Author>
            {
                new Author {FirstName = "Ioan", LastName = "Slavici", BirthDate = new DateTime(1895, 05, 15), DeathDate = new DateTime(1983, 12, 13)},
                new Author {FirstName = "Mihai", LastName = "Eminescu", BirthDate = new DateTime(1885, 01, 15), DeathDate = new DateTime(1951, 06, 15)}
            };

            apContext.Authors.AddRange(authors);
            apContext.SaveChanges();

            var people = new List<Person>
            {
                new Person
                {
                    FirstName = "Aurel",
                    LastName = "Popescu",
                    Cnp = "183206483",
                    Address = "Buzau",
                    Phone = "072264786",
                    Email = "aurel@gmail.com"
                },
                new Person
                {
                    FirstName = "Mihai",
                    LastName = "Farafastoaca",
                    Cnp = "18903741983",
                    Address = "Arges",
                    Phone = "0722636468",
                    Email = "mihai@gmail.com"
                }
            };

            apContext.People.AddRange(people);
            apContext.SaveChanges();

            var genders = new List<Gender>
            {
                new Gender {Name = "Medicina"},
                new Gender {Name = "Literatura straina"},
                new Gender {Name = "Literatura romana"},
                new Gender {Name = "Tehnica"}
            };

            apContext.Genders.AddRange(genders);
            apContext.SaveChanges();

            var books = new List<Book>
            {
                new Book
                {
                    Author = authors[1],
                    Title = "Poezii",
                    Year = 1978,
                    Gender = genders[2],
                    Isbn = "b3eh34567"
                },
                new Book
                {
                    Author = authors[0],
                    Title = "Moara cu noroc",
                    Year = 1986,
                    Gender = genders[2],
                    Isbn = "ks63789"
                }
            };

            apContext.Books.AddRange(books);
            apContext.SaveChanges();

            var bookExemplaries = new List<BookExemplary>
            {
                new BookExemplary { Book = books[0], Code = "4567890"},
                new BookExemplary { Book = books[1], Code = "7694033"}
            };

            apContext.BookExemplaries.AddRange(bookExemplaries);
            apContext.SaveChanges();

            var loans = new List<Loan>
            {
                new Loan {Person = people[0], BookExemplary = bookExemplaries[0], FromDate = new DateTime(2017, 11, 15), ToDate = new DateTime(2017, 12, 10)},
                new Loan {Person = people[1], BookExemplary = bookExemplaries[1], FromDate = new DateTime(2017, 11, 29), ToDate = new DateTime(2017, 12, 27)}
            };

            apContext.Loans.AddRange(loans);
            apContext.SaveChanges();
        }
    }
}
