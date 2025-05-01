using System.ComponentModel.DataAnnotations;

namespace BLL.Models
{
    public class Word
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Text { get; set; }

        [StringLength(50)]
        public string PartOfSpeech { get; set; }

        [Required]
        [StringLength(500)]
        public string Translation { get; set; }

        [StringLength(1000)]
        public string Phrase { get; set; }

        [StringLength(1000)]
        public string Example { get; set; }

        public WordLevel Level { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<UserWordProgress> UserProgresses { get; set; }
    }

    public enum WordLevel
    {
        CET4,
        CET6,
        JuniorHigh,
        SeniorHigh,
        TOEFL
    }
} 