using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Artist
    {
        public Artist()
        {
            this.AlbumArtists = new List<AlbumArtist>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<AlbumArtist> AlbumArtists { get; set; }

    }
}
