using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book.Models
{
    public class SongDbContext: DbContext
    {
        public SongDbContext(DbContextOptions<SongDbContext> options): base(options)
        {

        }
        public DbSet<Song> Song { get; set; }
    }
}
