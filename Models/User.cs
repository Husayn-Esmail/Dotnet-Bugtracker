using System.ComponentModel.DataAnnotations;

namespace bugtracker.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
        // issues that the user has access to.
        public Issue[]? Issues { get; set; }
    }
}