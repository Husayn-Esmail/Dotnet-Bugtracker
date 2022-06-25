using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using bugtracker.Models;

    public class BugtrackerContext : DbContext
    {
        public BugtrackerContext (DbContextOptions<BugtrackerContext> options)
            : base(options)
        {
        }

        public DbSet<bugtracker.Models.Issue>? Issue { get; set; }
    }
