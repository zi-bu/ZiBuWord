using System.ComponentModel.DataAnnotations;

namespace BLL.Models
{
    public class LoginAttempt
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public DateTime AttemptTime { get; set; }

        public bool IsSuccessful { get; set; }

        [StringLength(50)]
        public string IpAddress { get; set; }

        [StringLength(500)]
        public string UserAgent { get; set; }

        public virtual User User { get; set; }
    }
} 