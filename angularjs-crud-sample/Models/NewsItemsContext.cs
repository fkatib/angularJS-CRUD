using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace angularjs_crud_sample.Models
{
    public class NewsItemsContext : DbContext
    {
        public NewsItemsContext()
            : base("name=DefaultConnection")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<NewsItem> NewsItems { get; set; }
    }
}