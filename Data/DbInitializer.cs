﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nohai_Dragos_Ionut_Lab2.Models;

namespace Nohai_Dragos_Ionut_Lab2.Data
{
    public class DbInitializer
    {
        public static void Initialize(LibraryContext context)
        {
            context.Database.EnsureCreated();
            if(context.Books.Any())
            {
                return;
            }

            var books = new Book[]
            {
                new Book{Title="Baltagul", Author="Mihail Sadoveanu", Price=Decimal.Parse("22")},
                new Book{Title="Ion", Author="Liviu Rebreanu", Price=Decimal.Parse("18")},
                new Book{Title="Enigma Otiliei", Author="George Calinescu", Price=Decimal.Parse("18")}
            };
            foreach(Book s in books)
            {
                context.Books.Add(s);
            }
            context.SaveChanges();

            var customers = new Customer[]
            {
                new Customer{CustomerID=1050, Name="Popescu Ioan", BirthDate=DateTime.Parse("1979-09-01")},
                new Customer{CustomerID=1055, Name="Nohai Dragos", BirthDate=DateTime.Parse("1998-01-15")},
            };
            foreach(Customer c in customers)
            {
                context.Customers.Add(c);
            }
            context.SaveChanges();

            var orders = new Order[]
            {
                new Order{BookID=1, CustomerID=1050},
                new Order{BookID=3, CustomerID=1055},
                new Order{BookID=1, CustomerID=1055},
                new Order{BookID=2, CustomerID=1050},

            };
            foreach(Order e in orders)
            {
                context.Orders.Add(e);
            }
            context.SaveChanges();
        }
    }
}
