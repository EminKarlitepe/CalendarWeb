using CalendarWeb.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CalendarWeb.Context
{
    public class CalendarContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Event> Events { get; set; }
    }
}