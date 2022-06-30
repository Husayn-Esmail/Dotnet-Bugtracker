using System.ComponentModel.DataAnnotations;

namespace bugtracker.Models
{
    public class JointUserIssue
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int IssueId { get; set; }
    }
}