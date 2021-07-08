using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectsAndTasks.Models
{
    public class Project
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public int Priority { get; set;}
        public int Id { get; set; }
       // public List<Post> Posts { get; set; }
    }
}
