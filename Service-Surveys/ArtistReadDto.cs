namespace Surveys.Models
{
    public class ArtistReadDto
    {
        public int Id { get; set; }

        public string PromotionIdeas { get; set; }

        public byte[] Picture { get; set; }
   
        public string FacebookLink { get; set; }
 
        public string InstagramHandle { get; set; }
   
        public string SoundcloudLink { get; set; }

        public string SpotifyLink { get; set; }
 
        public string YoutubeLink { get; set; }

        public string OtherLinkDescription1 { get; set; }

        public string OtherLinkDescription2 { get; set; }
  
        public string OtherLinkDescription3 { get; set; }
 
        public string OtherLink1 { get; set; }
  
        public string OtherLink2 { get; set; }
 
        public string OtherLink3 { get; set; }
    }
}