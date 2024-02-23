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
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        [Required(ErrorMessage = "The Title is Required.")]
        public string Title { get; set; }
        [Range(1888, 2024, ErrorMessage = "Year must be from 1888 up to the present year.")]
        public int Year { get; set; }
        public string? Director { get; set; }
        public string? Rating { get; set; }
        [Required(ErrorMessage = "The Edited Field is Required.")]
        public Boolean Edited { get; set; }
        public string? LentTo { get; set; }
        [Required(ErrorMessage = "The Plex Field is Required.")]
        public Boolean CopiedToPlex { get; set; }
        public string? Notes { get; set; }
    }
}
