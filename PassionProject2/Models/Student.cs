using System;
using System.Collections.Generic;

namespace PassionProject2.Models
{
    public partial class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int? GradeId { get; set; }

        public Grade Grade { get; set; }
    }
}
