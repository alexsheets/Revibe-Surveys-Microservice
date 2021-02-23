using System.ComponentModel.DataAnnotations;

namespace Surveys.Models
{
    public class ArtistOfTheWeek
    {
        [Key]
        public int Id {get; set;}

        public string PromotionIdeas { get; set; }

        public byte[] Picture { get; set; }

        [MaxLength(255)]    
        public string FacebookLink { get; set; }

        [MaxLength(255)]   
        public string InstagramHandle { get; set; }

        [MaxLength(255)]   
        public string SoundcloudLink { get; set; }

        [MaxLength(255)]   
        public string SpotifyLink { get; set; }

        [MaxLength(255)]   
        public string YoutubeLink { get; set; }

        [MaxLength(255)]   
        public string OtherLinkDescription1 { get; set; }

        [MaxLength(255)]   
        public string OtherLinkDescription2 { get; set; }

        [MaxLength(255)]   
        public string OtherLinkDescription3 { get; set; }

        [MaxLength(255)]   
        public string OtherLink1 { get; set; }

        [MaxLength(255)]   
        public string OtherLink2 { get; set; }

        [MaxLength(255)]   
        public string OtherLink3 { get; set; }
    }
}