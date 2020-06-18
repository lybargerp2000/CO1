using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CO.Models;

namespace CO.Data
{
    public class COContext : DbContext
    {
        public COContext (DbContextOptions<COContext> options)
            : base(options)
        {
        }

        public DbSet<CO.Models.Associate> Associate { get; set; }
    }
}
