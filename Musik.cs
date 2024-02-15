using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musikkspiller_App
{
    internal class Musik
    {
        public Musik(string songName, string artist, int year, string category, bool isFavorite = false)
        {
            SongName = songName;
            Artist = artist;
            Year = year;
            Category = category;
            IsFavorite = isFavorite;
        }

        public string SongName { get; private set; }
        public string Artist { get; private set; }
        public int Year { get; private set; }
        public string Category { get; private set; }
        public bool IsFavorite { get; set; }

    }
}
