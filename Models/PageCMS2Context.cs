using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PageCMS2.Models
{
    public class PageCMS2Context : DbContext
    {
        public DbSet<Page> Pages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Section> Sections { get; set; }
    }
}