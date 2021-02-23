using System;
using System.Collections.Generic;
using System.Linq;
using Surveys.Models;

namespace Surveys.Data
{
    public class SqlArtistOfTheWeekRepo : IArtistRepo
    {
        private readonly ArtistContext _context;

        public SqlArtistOfTheWeekRepo(ArtistContext context)
        {
            _context = context;
        }
        public IEnumerable<ArtistOfTheWeek> GetArtistsOfTheWeek()
        {
            return _context.ArtistsOfTheWeek.ToList();
        }
        public ArtistOfTheWeek GetArtistOfTheWeekById(int id)
        {
            return _context.ArtistsOfTheWeek.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void CreateArtistApplication(ArtistOfTheWeek artist)
        {
            if(artist == null)
            {
                throw new ArgumentNullException(nameof(artist));
            }
            _context.ArtistsOfTheWeek.Add(artist);
        }
    }
}