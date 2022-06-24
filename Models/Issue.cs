using System.ComponentModel.DataAnnotations;

namespace bugtracker.Models
{
    public class Issue
    {
        public int Id { get; set; }
        public string? Status { get; set; }
        public string? Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateTimeCreated { get; set; }
        public DateTime DateTimeModifed { get; set; }
        public string? Description { get; set; }
        public string? Priority { get; set; }
        public string? IssueType { get; set; }
        // Create a parameter for assigned users (list of users)
        // Create a parameter for who last modified (type user)
    }
}