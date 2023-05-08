using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L7.Models
{
    internal class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        [ForeignKey("GroupName")]
        public string StudentGroup { get; set;}
    }
}
