using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6_Nieves.Models
{
    public class FilmSubmission
    {
        [Key]
        [Required]
        public int MovieId { get; set; }
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Director { get; set; }
        public string Rating { get; set; }
        public Boolean? Edited { get; set; }
        public Boolean? CopiedToPlex { get; set; }
        public string? LentTo { get; set; }
        public string? Notes { get; set; }

    }
}
