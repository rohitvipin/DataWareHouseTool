using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using DataWareHouseTool.DAL.Models;
using DataWareHouseTool.DAL.Repositories.Interfaces;

namespace DataWareHouseTool.DAL.Repositories
{
    public class SystemDatabaseRepository : ISystemDatabaseRepository
    {
        private const string Query = "SELECT [dbid] as Id, [name] AS [Name], crdate AS CreatedDateTime FROM master.dbo.sysdatabases WHERE NAME NOT IN('master', 'tempdb', 'model', 'msdb') ";

        public IDbConnection DbConnection { get; set; }

        public async Task<IEnumerable<SystemDatabase>> Get()
        {
            var queryAsync = DbConnection.QueryAsync<SystemDatabase>(Query);
            return queryAsync != null ? await queryAsync : null;
        }

        public async Task<IEnumerable<SystemDatabase>> GetByName(string name)
        {
            var queryAsync = DbConnection.QueryAsync<SystemDatabase>($"{Query} AND NAME = @Name", new { Name = name });
            return queryAsync != null ? await queryAsync : null;
        }

        public Task<SystemDatabase> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Insert(SystemDatabase item)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Update(SystemDatabase item)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}