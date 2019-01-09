using System;
using System.Collections.Generic;

namespace PassionProject2.Models
{
    public partial class Grade
    {
        public Grade()
        {
            Student = new HashSet<Student>();
        }

        public int GradeId { get; set; }
        public int? AssignmentId { get; set; }
        public int? Grade1 { get; set; }

        public Assignment Assignment { get; set; }
        public ICollection<Student> Student { get; set; }
    }
}
