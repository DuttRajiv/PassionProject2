using System;
using System.Collections.Generic;

namespace PassionProject2.Models
{
    public partial class Assignment
    {
        public Assignment()
        {
            Grade = new HashSet<Grade>();
        }

        public int AssignmentId { get; set; }
        public string AssignmentName { get; set; }
        public string Course { get; set; }

        public ICollection<Grade> Grade { get; set; }
    }
}
