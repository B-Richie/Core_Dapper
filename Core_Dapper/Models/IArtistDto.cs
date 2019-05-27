using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Dapper.Models
{
    public interface IArtistDto
    {
        int ArtistID { get; set; }

        string ArtistName { get; set; }

        ICollection<IAlbumDto> Albums { get; set; }
    }
}
