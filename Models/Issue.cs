using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bugtracker.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BugtrackerContext(
                serviceProvider.GetRequiredService<
                DbContextOptions<BugtrackerContext>>()))
                {
                    // Look for any issues
                    if (context.Issue.Any())
                    {
                        return; // DB has been seeded
                    }
                    context.Issue.AddRange(
                        new Issue
                        {
                            Title = "First issue",
                            Description = "the first issue existed"
                        },
                        new Issue
                        {
                            Title = "Second issue",
                            Description = "the second issue existed"
                        },
                        new Issue
                        {
                            Title = "Third issue",
                            Description = "the third issue existed"
                        },
                        new Issue
                        {
                            Title = "Fourth issue",
                            Description = "the fourth issue existed"
                        }
                    );
                    context.SaveChanges();
                }
        }
    }
    public class Issue
    {
        [Key]
        public int Id { get; set; }
        public string? Status { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Priority { get; set; }
        [Display(Name = "Issue type")]
        public string? IssueType { get; set; }
        [Display(Name = "Created")]
        public DateTime DateTimeCreated { get; set; }
        [Display(Name = "Modified")]
        public DateTime DateTimeModified { get; set; }
        [Display(Name = "Last Modified By")]
        public int? LastModifiedBy { get; set; }

        // public void Init()
        // {
        //     if (this.DateTimeCreated == null)
        //     {
        //         this.DateTimeCreated = DateTime.Now;
        //         this.DateTimeModified = DateTime.Now;
        //         this.Status = "open";
        //         Console.WriteLine("**********************INITED**********************");
        //     }
        // }
        
        // public Issue() {
        //     Init();
        // }

        public void UpdateTimeModified() {
            this.DateTimeCreated = this.DateTimeCreated;
            this.DateTimeModified = DateTime.Now;
            Console.WriteLine("**********************UPDATED**********************");
        }
    }
}