using System.ComponentModel.DataAnnotations;

namespace Surveys.Dtos
{
    public class SendEmailDto
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public string Email { get; set; }

        public string Subject { get; set; }

        [Required]
        public string Message { get; set; }

        public string Platform { get; set; }

    }
}