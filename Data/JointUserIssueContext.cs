using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using bugtracker.Models;

    public class JointUserIssueContext : DbContext
    {
        public JointUserIssueContext (DbContextOptions<JointUserIssueContext> options)
            : base(options)
        {
        }

        public DbSet<bugtracker.Models.JointUserIssue>? JointUserIssue { get; set; }
    }
