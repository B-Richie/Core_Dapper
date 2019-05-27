using AutoMapper;
using Core_Dapper.Models;
using Dapper;
using Dapper_DAL.BaseService;
using Dapper_DAL.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Dapper.Services
{
    public class ArtistService : BaseService, IArtistService
    {
        private readonly IMapper _mapper;
        private readonly DatabaseConnections _DatabaseConnections;
        private readonly IOracleParameterFactory _parameterFactory;
        protected override IDbConnection Connection { get; set; }
        protected override string SQL { get; set; }

        protected override Artist Get<Artist>(int id)
        {
            SQL = "Select * from dbo.Artist a where a.ArtistID = :id";

            var result = base.Get<Artist>(id);
            return result;
        }

        public ArtistService(IMapper mapper, DatabaseConnections databaseConnections, IOracleParameterFactory parameterFactory)
        {
            _mapper = mapper;
            _DatabaseConnections = databaseConnections;
            _parameterFactory = parameterFactory;
            Connection = _DatabaseConnections.MSSqlConnections.Where(alias => alias.Alias == "Music").FirstOrDefault().dbConnection;
        }

        public async Task<IEnumerable<IArtistDto>> GetListAsync()
        {
            const string sql = "Select * from dbo.Artist";
            var result = await QueryAsync<Artist>(sql);
            var mappedResult = _mapper.Map<IEnumerable<IArtistDto>>(result);
            return mappedResult;
        }

        public IEnumerable<IArtistDto> GetList()
        {
            const string sql = "Select * from dbo.Artist";
            var result = Query<Artist>(sql);
            var mappedResult = _mapper.Map<IEnumerable<IArtistDto>>(result);
            return mappedResult;
        }


        public async Task<IArtistDto> CallProcedureAsync(string Id)
        {
            const string sql = "GET_ARTIST";
            var param2 = _parameterFactory.CreateOracleParameters();
            param2.Add("artistId", OracleDbType.Int32, ParameterDirection.Input, Id);
            param2.Add("artist", OracleDbType.RefCursor, ParameterDirection.Output);
            var result = await QueryFirstOrDefaultAsync<Artist>(sql, param2, null, null, CommandType.StoredProcedure);
            var mappedResult = _mapper.Map<IArtistDto>(result);
            return mappedResult;
        }
        public IArtistDto CallProcedure(string Id)
        {
            const string sql = "GET_ARTIST";
            var param2 = _parameterFactory.CreateOracleParameters();
            param2.Add("artistId", OracleDbType.Int32, ParameterDirection.Input, Id);
            param2.Add("artist", OracleDbType.RefCursor, ParameterDirection.Output);
            var result = QueryFirstOrDefault<Artist>(sql, param2, null, null, CommandType.StoredProcedure);
            var mappedResult = _mapper.Map<IArtistDto>(result);
            return mappedResult;
        }

        public IArtistDto GetFirstOrDefault(int id)
        {
            const string sql = "Select * from dbo.Artist a where a.ArtistID = @id";
            var result = QueryFirstOrDefault<Artist>(sql, new { id });
            var model = _mapper.Map<IArtistDto>(result);
            return model;
        }

        public async Task<IArtistDto> GetFirstOrDefaultAsync(int id)
        {
            const string sql = "Select * from dbo.Artist a where a.ArtistID = @id";
            var result = await QueryFirstOrDefaultAsync<Artist>(sql, new { id });
            var model = _mapper.Map<IArtistDto>(result);
            return model;
        }

        public async Task<int> DeleteAsync(decimal id)
        {
            const string sql = "Delete from dbo.Artist a where a.ArtistID = :id";
            var result = await ExecuteAsync(sql, new { id });
            return result;
        }

        public int Delete(decimal id)
        {
            const string sql = "Delete from dbo.Artist a where a.ArtistID = :id";
            var result = Execute(sql, new { id });
            return result;
        }

        public async Task<int> UpdateAsync(IArtistDto model)
        {
            var dbModel = _mapper.Map<Artist>(model);
            var param = new DynamicParameters(dbModel);
            param.Add("ArtistID", model.ArtistID, DbType.Int32, ParameterDirection.Input);
            const string sql = "update dbo.Artist a set a.ArtistName = @ArtistName where a.ArtistID = @ArtistID";
            var result = await ExecuteAsync(sql, param);
            return result;
        }

        public int Update(IArtistDto model)
        {
            var dbModel = _mapper.Map<Artist>(model);
            var param = new DynamicParameters(dbModel);
            param.Add("ArtistID", model.ArtistID, DbType.Int32, ParameterDirection.Input);
            const string sql = "update dbo.Artist a set a.ArtistName = @ArtistName where a.ArtistID = @ArtistID";
            var result = Execute(sql, param);
            return result;
        }

        public int Insert(IArtistDto model)
        {
            var dbModel = _mapper.Map<Artist>(model);
            var param = new DynamicParameters(dbModel);
            param.Add("ArtistID", null, DbType.Int32, ParameterDirection.Output);
            const string sql = "insert into dbo.Artist (ArtistName) VALUES ( @ArtistName)";
            
            var result = Execute(sql, param);

            return result;
        }

        public async Task<int> InsertAsync(IArtistDto model)
        {
            var dbModel = _mapper.Map<Artist>(model);
            var param = new DynamicParameters(dbModel);
            param.Add("ArtistID", null, DbType.Int32, ParameterDirection.Output);
            const string sql = "insert into dbo.Artist (ArtistName) VALUES ( @ArtistName)";

            var result = await ExecuteAsync(sql, param);
            return result;
        }

        public Task<int> ExecuteTransaction(IArtistDto model)
        {
            throw new NotImplementedException();
        }

        public IArtistDto GetOverride(int id)
        {
            var result = Get<Artist>(id);

            var dbModel = _mapper.Map<IArtistDto>(result);

            return dbModel;

        }
    }
}
