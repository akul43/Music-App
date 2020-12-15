using System;

#nullable disable

namespace Music.Models
{
    public partial class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Genre { get; set; }
        public int LabelId { get; set; }

        public virtual Label Label { get; set; }
    }
}
