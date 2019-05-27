using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Dapper.Models
{
    public interface IAlbumDto
    {
        int AlbumID { get; set; }
        string AlbumName { get; set; }
        Int32 NumberOfTracks { get; set; }
        Int32 ReleaseYear { get; set; }
        decimal Cost { get; set; }
        string Genre { get; set; }
        int? ArtistID { get; set; }
        IArtistDto Artist { get; set; }
        ICollection<ITrackDto> Tracks { get; set; }
    }
}
