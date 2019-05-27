using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Dapper.Models
{
    public class TrackDto : ITrackDto
    {
        public int TrackID { get; set; }
        public string TrackName { get; set; }
        public int? AlbumID { get; set; }
        public IAlbumDto Album { get; set; }
    }
}
