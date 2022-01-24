using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Album
    {
        public Album()
        {
            this.Artists = new HashSet<Artist>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime PublishDate { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Artist> Artists { get; set; }
    }
}
