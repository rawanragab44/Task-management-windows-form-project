using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationProject.Models
{

    public enum Enum
    {
        Pending,
        InProgress,
        Completed
    }
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string Priority { get; set; } // Low, Medium, High
        public Enum Status { get; set; } // Pending, In Progress, Completed

        //foreign key for one to many relation between task item and user
        [ForeignKey("User")]
        public int UserID { get; set; }
        public User User { get; set; }


        //foreign key for one to many relation between task item and category
        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
