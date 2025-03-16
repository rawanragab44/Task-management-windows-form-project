using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationProject.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }


        //foreign key for one to many relation between task item and category
        public ICollection<TaskItem> TaskItems { get; set; } = new List<TaskItem>();

    }
}
