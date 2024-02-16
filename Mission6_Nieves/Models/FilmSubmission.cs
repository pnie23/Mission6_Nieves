using System.ComponentModel.DataAnnotations;

namespace Mission6_Nieves.Models
{
    public class FilmSubmission
    {
        [Key]
        [Required]
        public int FormSubmissionId { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Director { get; set; }
        public string Rating { get; set; }
        public Boolean? Edited { get; set; }
        public string? LentTo { get; set; }
        public string? Notes { get; set; }

    }
}
