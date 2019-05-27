using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Dapper.Models
{
    public class ArtistDto : IArtistDto
    {
        public int ArtistID { get; set; }

        public string ArtistName { get; set; }

        public ICollection<IAlbumDto> Albums { get; set; }
    }
}
