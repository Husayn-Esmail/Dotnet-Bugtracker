using System.ComponentModel.DataAnnotations;

namespace bugtracker.Models
{
    public class Issue
    {
        public int Id { get; set; }
        public string? Status { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Priority { get; set; }
        public string? IssueType { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public DateTime DateTimeModifed { get; set; }
        // FIXME: Databases cannot store lists, figure out another way to keep track of assigned users.
        // Trying to circumvent this limitation is bad practice and should not be used.
        // This is also going to be an issue within the User Model.
        public int? LastModifiedBy { get; set; }
    }
}