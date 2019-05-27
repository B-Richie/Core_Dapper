using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Dapper.Models
{
    public class AlbumDto : IAlbumDto
    {
        public int AlbumID { get; set; }
        public string AlbumName { get; set; }
        public Int32 NumberOfTracks { get; set; }

        public Int32 ReleaseYear { get; set; }

        public decimal Cost { get; set; }
        public string Genre { get; set; }

        public int? ArtistID { get; set; }

        public IArtistDto Artist { get; set; }
        public ICollection<ITrackDto> Tracks { get; set; }
    }
}
