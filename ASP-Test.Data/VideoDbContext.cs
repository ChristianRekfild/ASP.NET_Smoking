using ASP_Test.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Test.Data
{
    internal class VideoDbContext : DbContext
    {
        public VideoDbContext(DbContextOptions<VideoDbContext> dbContextOptns) : base(dbContextOptns)
        {
        }

        public DbSet<Video> Videos { get; set; }
    }
}
