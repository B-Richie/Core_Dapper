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
            SQL = "Select * from web_rlc_adm.b2b_activity_queue b where b.activity_id = :id";

            var result = base.Get<Artist>(id);
            return result;
        }

        public ArtistService(IMapper mapper, DatabaseConnections databaseConnections, IOracleParameterFactory parameterFactory)
        {
            _mapper = mapper;
            _DatabaseConnections = databaseConnections;
            _parameterFactory = parameterFactory;
            Connection = _DatabaseConnections.OracleConnections.Where(alias => alias.Alias == "WebRlc").FirstOrDefault().dbConnection;
        }

        public async Task<IEnumerable<IArtistDto>> GetListAsync(int activityToolType)
        {
            const string sql = "Select * from web_rlc_adm.b2b_activity_queue b where b.activity_tool_type = :activityToolType";
            var result = await QueryAsync<Artist>(sql, new { activityToolType });
            var mappedResult = _mapper.Map<IEnumerable<IArtistDto>>(result);
            return mappedResult;
        }

        public IEnumerable<IArtistDto> GetList(int activityToolType)
        {
            const string sql = "Select * from web_rlc_adm.b2b_activity_queue b where b.activity_tool_type = :activityToolType";
            var result = Query<Artist>(sql, new { activityToolType });
            var mappedResult = _mapper.Map<IEnumerable<IArtistDto>>(result);
            return mappedResult;
        }


        public async Task<IArtistDto> CallProcedureAsync(string quoteNumber)
        {
            const string sql = "web_rlc_adm.GET_RATE_QUOTE";
            var param2 = _parameterFactory.CreateOracleParameters();
            //var param2 = new OracleDynamicParameters();
            param2.Add("pi_quote_number", OracleDbType.Varchar2, ParameterDirection.Input, quoteNumber);
            param2.Add("po_rate_quote_xml_clob", OracleDbType.RefCursor, ParameterDirection.Output);
            //param2.Add("po_errMsg", OracleDbType.Varchar2, ParameterDirection.Output, null, 32767);
            //param2.Add("po_errMsg", OracleDbType.Varchar2, ParameterDirection.Output);

            var result = await QueryFirstOrDefaultAsync<Artist>(sql, param2, null, null, CommandType.StoredProcedure);
            var mappedResult = _mapper.Map<IArtistDto>(result);
            return mappedResult;
        }
        public IArtistDto CallProcedure(string quoteNumber)
        {
            const string sql = "web_rlc_adm.GET_RATE_QUOTE";
            var param2 = _parameterFactory.CreateOracleParameters();
            //var param2 = new OracleDynamicParameters();
            param2.Add("PI_QUOTE_NUMBER", OracleDbType.Varchar2, ParameterDirection.Input, quoteNumber);
            param2.Add("PO_RATE_QUOTE", OracleDbType.RefCursor, direction: ParameterDirection.Output);
            var result = QueryFirstOrDefault<Artist>(sql, param2, null, null, CommandType.StoredProcedure);
            var mappedResult = _mapper.Map<IArtistDto>(result);
            return mappedResult;
        }

        public IArtistDto GetFirstOrDefault(int id)
        {
            const string sql = "Select * from web_rlc_adm.b2b_activity_queue b where b.activity_id = :id";
            var result = QueryFirstOrDefault<Artist>(sql, new { id });
            var model = _mapper.Map<IArtistDto>(result);
            return model;
        }

        public async Task<IArtistDto> GetFirstOrDefaultAsync(int id)
        {
            const string sql = "Select * from web_rlc_adm.b2b_activity_queue b where b.activity_id = :id";
            var result = await QueryFirstOrDefaultAsync<Artist>(sql, new { id });
            var model = _mapper.Map<IArtistDto>(result);
            return model;
        }

        public async Task<int> DeleteAsync(decimal id)
        {
            const string sql = "Delete from web_rlc_adm.b2b_activity_queue b where b.activity_id = :id";
            var result = await ExecuteAsync(sql, new { id });
            return result;
        }

        public int Delete(decimal id)
        {
            const string sql = "Delete from web_rlc_adm.b2b_activity_queue b where b.activity_id = :id";
            var result = Execute(sql, new { id });
            return result;
        }

        public async Task<int> UpdateAsync(IArtistDto model)
        {
            var dbModel = _mapper.Map<Artist>(model);
            var param = new DynamicParameters(dbModel);
            param.Add("Id", model.ArtistID, DbType.Decimal, ParameterDirection.Input);
            const string sql = "update WEB_RLC_ADM.B2B_ACTIVITY_QUEUE b set b.CREATED_ON = :CREATED_ON, b.ACTIVITY_TOOL_TYPE = :ACTIVITY_TOOL_TYPE, b.ACTIVITY_USER_ID = :ACTIVITY_USER_ID, b.ACTIVITY_STATUS = :ACTIVITY_STATUS, b.SHOW_ON_HOME_PAGE = :SHOW_ON_HOME_PAGE, b.REQUEST_XML = :REQUEST_XML, b.LAST_UPDATE = :LAST_UPDATE, b.DATA_1 = :DATA_1, b.DATA_2 = :DATA_2, b.DATA_3 = :DATA_3, b.DATA_4 = :DATA_4, b.DATA_5 = :DATA_5, b.SUCCESS = :SUCCESS, b.RESPONSE_XML = :RESPONSE_XML, b.ERROR_MESSAGE = :ERROR_MESSAGE, b.SERVICE_ENDPOINT = :SERVICE_ENDPOINT where b.activity_id = :Id";
            var result = await ExecuteAsync(sql, param);
            return result;
        }

        public int Update(IArtistDto model)
        {
            var dbModel = _mapper.Map<Artist>(model);
            var param = new DynamicParameters(dbModel);
            param.Add("Id", model.ArtistID, DbType.Decimal, ParameterDirection.Input);
            const string sql = "update WEB_RLC_ADM.B2B_ACTIVITY_QUEUE b set b.CREATED_ON = :CREATED_ON, b.ACTIVITY_TOOL_TYPE = :ACTIVITY_TOOL_TYPE, b.ACTIVITY_USER_ID = :ACTIVITY_USER_ID, b.ACTIVITY_STATUS = :ACTIVITY_STATUS, b.SHOW_ON_HOME_PAGE = :SHOW_ON_HOME_PAGE, b.REQUEST_XML = :REQUEST_XML, b.LAST_UPDATE = :LAST_UPDATE, b.DATA_1 = :DATA_1, b.DATA_2 = :DATA_2, b.DATA_3 = :DATA_3, b.DATA_4 = :DATA_4, b.DATA_5 = :DATA_5, b.SUCCESS = :SUCCESS, b.RESPONSE_XML = :RESPONSE_XML, b.ERROR_MESSAGE = :ERROR_MESSAGE, b.SERVICE_ENDPOINT = :SERVICE_ENDPOINT where b.activity_id = :Id";
            var result = Execute(sql, param);
            return result;
        }

        public int Insert(IArtistDto model)
        {
            var dbModel = _mapper.Map<Artist>(model);
            var param = new DynamicParameters(dbModel);
            param.Add("ArtistID", null, DbType.Int32, ParameterDirection.Output);
            const string sql = "insert into WEB_RLC_ADM.B2B_ACTIVITY_QUEUE (ACTIVITY_ID, CREATED_ON, ACTIVITY_TOOL_TYPE, ACTIVITY_USER_ID, ACTIVITY_STATUS, SHOW_ON_HOME_PAGE, REQUEST_XML, LAST_UPDATE, DATA_1, DATA_2, DATA_3, DATA_4, DATA_5, SUCCESS, RESPONSE_XML, ERROR_MESSAGE, SERVICE_ENDPOINT) VALUES ( web_rlc_adm.B2B_ACTIVITY_QUEUE_SEQ.NextVal, :CREATED_ON, :ACTIVITY_TOOL_TYPE, :ACTIVITY_USER_ID, :ACTIVITY_STATUS, :SHOW_ON_HOME_PAGE, :REQUEST_XML, :LAST_UPDATE, :DATA_1, :DATA_2, :DATA_3, :DATA_4, :DATA_5, :SUCCESS, :RESPONSE_XML, :ERROR_MESSAGE, :SERVICE_ENDPOINT) returning ACTIVITY_ID into :Id";

            var result = Execute(sql, param);
            var Id = param.Get<int>("Id");
            return Id;
        }

        public async Task<int> InsertAsync(IArtistDto model)
        {
            var dbModel = _mapper.Map<Artist>(model);
            var param = new DynamicParameters(dbModel);
            param.Add("ArtistID", null, DbType.Int32, ParameterDirection.Output);
            const string sql = "insert into WEB_RLC_ADM.B2B_ACTIVITY_QUEUE (ACTIVITY_ID, CREATED_ON, ACTIVITY_TOOL_TYPE, ACTIVITY_USER_ID, ACTIVITY_STATUS, SHOW_ON_HOME_PAGE, REQUEST_XML, LAST_UPDATE, DATA_1, DATA_2, DATA_3, DATA_4, DATA_5, SUCCESS, RESPONSE_XML, ERROR_MESSAGE, SERVICE_ENDPOINT) VALUES ( web_rlc_adm.B2B_ACTIVITY_QUEUE_SEQ.NextVal, :CREATED_ON, :ACTIVITY_TOOL_TYPE, :ACTIVITY_USER_ID, :ACTIVITY_STATUS, :SHOW_ON_HOME_PAGE, :REQUEST_XML, :LAST_UPDATE, :DATA_1, :DATA_2, :DATA_3, :DATA_4, :DATA_5, :SUCCESS, :RESPONSE_XML, :ERROR_MESSAGE, :SERVICE_ENDPOINT) returning ACTIVITY_ID into :Id";

            var result = await ExecuteAsync(sql, param);
            var Id = param.Get<int>("Id");
            return Id;
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
