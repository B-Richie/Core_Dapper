using Core_Dapper.Models;
using Core_Dapper.Services;
using Microsoft.EntityFrameworkCore.InMemory.Storage.Internal;
using RLC.GlobalLibrary.Models.WebRlc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace DapperUnitTests
{
    public class ArtistServiceFake : IArtistService
    {
        private readonly List<IArtistDto> _queues;

        public ArtistServiceFake()
        {
            _queues = new List<IArtistDto>()
            {
                new ArtistDto
                {
                    ArtistID = 1,
                    ArtistName = "My new test artist"
                },

            };
        }

        public IArtistDto CallProcedure(string quoteNumber)
        {
            throw new NotImplementedException();
        }

        public Task<IArtistDto> CallProcedureAsync(string quoteNumber)
        {
            //var db = new InMemoryDatabase();
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public int Delete(decimal id)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(decimal id)
        {
            throw new NotImplementedException();
        }

        public Task<int> ExecuteTransaction(IArtistDto model)
        {
            throw new NotImplementedException();
        }

        public IArtistDto GetFirstOrDefault(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IArtistDto> GetFirstOrDefaultAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IArtistDto> GetList()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IArtistDto>> GetListAsync()
        {
            throw new NotImplementedException();
        }


        public IArtistDto GetOverride(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Insert(IArtistDto model)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAsync(IArtistDto model)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(IArtistDto model)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(IArtistDto model)
        {
            throw new NotImplementedException();
        }

        int IArtistService.Insert(IArtistDto model)
        {
            throw new NotImplementedException();
        }

        int IArtistService.Update(IArtistDto model)
        {
            throw new NotImplementedException();
        }
    }
}
