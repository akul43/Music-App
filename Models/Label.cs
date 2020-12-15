using System;
using System.Collections.Generic;

#nullable disable

namespace Music.Models
{
    public partial class Label
    {
        public Label()
        {
            Songs = new HashSet<Song>();
        }

        public int Id { get; set; }
        public string Artist { get; set; }
        public string LabelName { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
    }
}
