using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationProject.Models
{
    public class TaskManagementDB : DbContext
    {
        public DbSet <User> users {  get; set; }
        public DbSet <TaskItem> tasks { get; set; }
        public DbSet<Category> Categories { get; set; }


        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=RAWAN;Database=TaskManagementDB;Trusted_Connection=True;Encrypt=False");
        }

    }
}
