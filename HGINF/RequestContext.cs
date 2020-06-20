using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace HGINF
{
    public class RequestContext: DbContext
    {

        public RequestContext()
           : base("DbConnection")
        { }

        public DbSet<Request> Requests { get; set; }

         public DbSet<IpPCnum> IpPCnums { get; set; }
    }
}
