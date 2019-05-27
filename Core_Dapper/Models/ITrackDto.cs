using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Dapper.Models
{
    public interface ITrackDto
    {
        int TrackID { get; set; }
        string TrackName { get; set; }
        int? AlbumID { get; set; }
        IAlbumDto Album { get; set; }
    }
}
