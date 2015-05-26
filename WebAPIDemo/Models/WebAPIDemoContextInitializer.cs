using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WebAPIDemo.Models
{
    public class WebAPIDemoContextInitializer : DropCreateDatabaseAlways<WebAPIDemoContext>
    {
        protected override void Seed(WebAPIDemoContext context)
        {
            var books = new List<Book>() 
            { 
                new Book() { Author = "Tolstoy", Name = "War and Peace", Price = 19.95m }, 
                new Book() { Author = "Macken", Name = "Brown Lord of the Mountain", Price = 19.95m },
                new Book() { Author = "J.K. Rowling", Name = "Harry Potter", Price = 19.95m },
                new Book() { Author = "Ford", Name = "Independence Day", Price = 19.95m },
                new Book() { Author = "Roy", Name = "The God of Small Things", Price = 19.95m },
                new Book() { Author = "Blyton", Name = "The Famous Five", Price = 19.95m },
            };

            books.ForEach(b => context.Books.Add(b));
            context.SaveChanges();

            // Order no 1
            var order = new Order() { Customer = "John Doe", OrderDate = new DateTime(2014, 7, 10) };
            var details = new List<OrderDetail>() 
            {
                new OrderDetail() { Book = books[0], Quantity = 1, Order = order }, 
                new OrderDetail() { Book = books[2], Quantity = 2, Order = order }, 
                new OrderDetail() { Book = books[1], Quantity = 3, Order = order }
            };
            context.Orders.Add(order);
            details.ForEach(o => context.OrderDetails.Add(o));
            context.SaveChanges();

            // Order no 2
            order = new Order() { Customer = "Joe Smith", OrderDate = new DateTime(2014, 9, 18) };
            details = new List<OrderDetail>() 
            {
                new OrderDetail() { Book = books[1], Quantity = 1, Order = order }, 
                new OrderDetail() { Book = books[1], Quantity = 2, Order = order }, 
                new OrderDetail() { Book = books[3], Quantity = 12, Order = order }, 
                new OrderDetail() { Book = books[4], Quantity = 3, Order = order }
            };
            context.Orders.Add(order);
            details.ForEach(o => context.OrderDetails.Add(o));
            context.SaveChanges();

            // Order no 3
            order = new Order() { Customer = "Ward Bell", OrderDate = new DateTime(2014, 12, 25) };
            details = new List<OrderDetail>() 
            {
                new OrderDetail() { Book = books[2], Quantity = 1, Order = order }, 
                new OrderDetail() { Book = books[4], Quantity = 1, Order = order }, 
                new OrderDetail() { Book = books[3], Quantity = 1, Order = order }, 
                new OrderDetail() { Book = books[1], Quantity = 3, Order = order }
            };
            context.Orders.Add(order);
            details.ForEach(o => context.OrderDetails.Add(o));
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
