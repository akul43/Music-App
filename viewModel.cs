using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music
{
    public class viewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Genre { get; set; }

        public string LabelName { get; set; }
        public string Artist { get; set; }
    }
}
