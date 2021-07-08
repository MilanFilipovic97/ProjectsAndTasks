using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectsAndTasks.Models;

namespace ProjectsAndTasks.Models
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {
        }
      
        public DbSet<Project> ProjectItems { get; set; }
        public DbSet<TaskPr> TaskItems { get; set; }

        
    }
}
