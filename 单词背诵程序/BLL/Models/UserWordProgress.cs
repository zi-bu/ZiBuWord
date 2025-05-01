using System.ComponentModel.DataAnnotations;

namespace BLL.Models
{
    public class UserWordProgress
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int WordId { get; set; }
        public virtual Word Word { get; set; }

        public int ReviewCount { get; set; }
        public int CorrectCount { get; set; }
        public DateTime LastReviewTime { get; set; }
        public DateTime NextReviewTime { get; set; }
        public int MasteryLevel { get; set; } // 0-5，表示掌握程度

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
} 