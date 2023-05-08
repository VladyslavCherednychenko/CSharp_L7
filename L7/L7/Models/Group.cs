using System.ComponentModel.DataAnnotations;

namespace L7.Models
{
    internal class Group
    {
        [Key]
        public int GroupId { get; set; }
        public string GroupName { get; set; }
    }
}
