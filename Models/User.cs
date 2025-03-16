using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationProject.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } 


        //foreign key for one to many relation between task item and user
        public ICollection<TaskItem> TaskItems { get; set; } = new List<TaskItem>();


    }
}
