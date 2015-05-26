using Breeze.ContextProvider;
using Breeze.WebApi2;
using Newtonsoft.Json.Linq;

using System;
using System.Linq;

namespace WebAPIDemo.Models
{
    public interface IRepository
    {
        //System.Linq.IQueryable<Order> GetAllOrders();
        //System.Linq.IQueryable<Order> GetAllOrdersWithDetails();
        //Order GetOrder(int id);

        string Metadata { get; }

        SaveResult SaveChanges(JObject saveBundle);

        IQueryable<Book> Books();

        IQueryable<Order> Orders();
    }
}
