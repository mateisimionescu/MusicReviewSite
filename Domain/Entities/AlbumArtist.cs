using System;
namespace Domain.Entities
{
    public class AlbumArtist
    {
        public int Id { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public int AlbumId { get; set; }
        public Album Album { get; set; }
    }
}
