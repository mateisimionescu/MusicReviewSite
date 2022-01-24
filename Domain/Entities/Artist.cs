using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Artist
    {
        public Artist()
        {
            this.Albums = new HashSet<Album>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Album> Albums { get; set; }

    }
}
