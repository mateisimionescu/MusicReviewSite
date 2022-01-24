using System;
using System.Collections.Generic;
using Domain.Entities;

namespace WebApi.Helpers
{
    public class AlbumArtistHelper
    {
        public AlbumArtistHelper()
        { }
        public Album Album { get; set; }
        public List<int> ArtistIds { get; set; }
    }
}
