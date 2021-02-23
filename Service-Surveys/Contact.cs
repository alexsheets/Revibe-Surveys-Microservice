using System.ComponentModel.DataAnnotations;

namespace Surveys.Models
{
    public class Contact
    {
        [Key]
        public int Id {get; set;}
        [Required]
        [MaxLength(100)]
        public string FirstName {get; set;}
        public string LastName {get; set;}
        [Required]
        [MaxLength(250)]
        public string Email {get; set;}
        public string Subject {get; set;}
        [Required]
        public string Message {get; set;}
        [Required]
        public string Platform {get; set;}


    }
}