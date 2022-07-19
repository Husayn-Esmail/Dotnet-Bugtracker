using System.ComponentModel.DataAnnotations;

namespace bugtracker.Models
{
    public class JointUserIssue
    {  
        [Key]
        public int Id { get; set; }
        public User? User { get; set; }
        public Issue? Issue { get; set; }
    }
}