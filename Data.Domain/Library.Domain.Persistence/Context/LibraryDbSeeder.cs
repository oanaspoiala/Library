using System;
using System.Collections.Generic;
using System.Linq;
using Library.Core.Entities;

namespace Library.Persistence.Context
{
    public class LibraryDbSeeder
    {
        public static void Seed(LibraryDbContext apContext)
        {
            apContext.Database.EnsureCreated();
            if (!apContext.Authors.Any())
            {
                var author = new List<Author>
                {
                    new Author {FirstName = "Ioan", LastName = "Slavici"},
                    new Author {FirstName = "Mihai", LastName = "Eminescu"}
                };
                apContext.Authors.AddRange(author);
                apContext.SaveChanges();

                var person = new List<Person>
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
                apContext.People.AddRange(person);
                apContext.SaveChanges();

                var gender = new List<Gender>
                {
                    new Gender {Name = "Medicina"},
                    new Gender {Name = "Literatura straina"},
                    new Gender {Name = "Literatura romana"}
                };
                apContext.Genders.AddRange(gender);
                apContext.SaveChanges();

                var book = new List<Book>
                {
                    new Book
                    {
                        Author = author[0],
                        Title = "Poezii",
                        Year = 1978,
                        Gender = gender[0],
                        Isbn = "b3eh34567"
                    },
                    new Book
                    {
                        Author = author[1],
                        Title = "Moara cu noroc",
                        Year = 1986,
                        Gender = gender[1],
                        Isbn = "ks63789"
                    }
                };
                apContext.Books.AddRange(book);
                apContext.SaveChanges();

                var bookExemplary = new List<BookExemplary>
                {
                    new BookExemplary { Book = book[0], Code = "4567890", Loans = person[0]},
                    new BookExemplary { Book = book[1], Code = "7694033", Loans = person[1]}
                };
                apContext.BookExemplaries.AddRange(bookExemplary);
                apContext.SaveChanges();

                var loan = new List<Loan>
                {
                    new Loan {Person = person[0], BookExemplary = bookExemplary[0],FromDate = new DateTime(2017, 11, 15), ToDate = new DateTime(2017, 12, 10)},
                    new Loan {Person = person[0], BookExemplary = bookExemplary[0],FromDate = new DateTime(2017, 11, 29), ToDate = new DateTime(2017, 12, 27)}
                };
                apContext.Loans.AddRange(loan);
                apContext.SaveChanges();
            }
        }
    }
}
