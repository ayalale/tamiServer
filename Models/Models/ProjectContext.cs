using Microsoft.EntityFrameworkCore;
using ProjectChanuka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class ProjectContext:DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {

        }
        public DbSet<PostTable> Posts { get; set; }
        public DbSet<PhotoTable> Photo { get; set; }
        public DbSet<TodoTable> Todo { get; set; }
        public DbSet<UserTable> User { get; set; }
    }
}
