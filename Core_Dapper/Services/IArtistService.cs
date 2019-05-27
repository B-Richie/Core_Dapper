using Core_Dapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Dapper.Services
{
    public interface IArtistService
    {
        Task<IEnumerable<IArtistDto>> GetListAsync();
        Task<IArtistDto> GetFirstOrDefaultAsync(int id);
        IArtistDto GetFirstOrDefault(int id);
        IEnumerable<IArtistDto> GetList();
        Task<IArtistDto> CallProcedureAsync(string quoteNumber);
        IArtistDto CallProcedure(string quoteNumber);
        Task<int> InsertAsync(IArtistDto model);
        int Insert(IArtistDto model);
        Task<int> UpdateAsync(IArtistDto model);
        int Update(IArtistDto model);
        Task<int> DeleteAsync(decimal id);
        int Delete(decimal id);
        Task<int> ExecuteTransaction(IArtistDto model);
        IArtistDto GetOverride(int id);
    }
}
