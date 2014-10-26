namespace Visitors.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Visitors.Models;

    public class VisitorsDbContext : DbContext
    {
        public VisitorsDbContext()
            : base("name=Visitors")
        {
        }

        public IDbSet<Visitor> Visitors { get; set; }
    }
}