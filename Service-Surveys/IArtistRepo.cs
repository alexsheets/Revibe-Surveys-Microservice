using System.Collections.Generic;
using Surveys.Models;

namespace Surveys.Data
{
    public interface IArtistRepo
    {
        bool SaveChanges();
        IEnumerable<ArtistOfTheWeek> GetArtistsOfTheWeek();
        ArtistOfTheWeek GetArtistOfTheWeekById(int id);
        void CreateArtistApplication(ArtistOfTheWeek artist);
    }
}