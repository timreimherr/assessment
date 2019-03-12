using System;
using System.Collections.Generic;
using System.Text;
using Assessment.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Assessment.DataAccess
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options)
            : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
    }
}
