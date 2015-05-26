using Breeze.ContextProvider;
using Breeze.ContextProvider.EF6;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Newtonsoft.Json.Linq;

namespace WebAPIDemo.Models
{
    public class Repository : IRepository
    {
        private readonly EFContextProvider<WebAPIDemoContext> _contextProvider = new EFContextProvider<WebAPIDemoContext>();

        public string Metadata
        {
            get { return _contextProvider.Metadata(); }
        }

        public SaveResult SaveChanges(JObject saveBundle)
        {
            return _contextProvider.SaveChanges(saveBundle);
        }

        public IQueryable<Book> Books()
        {
            return _contextProvider.Context.Books;
        }

        public IQueryable<Order> Orders()
        {
            return _contextProvider.Context.Orders;
        }
    }
}
