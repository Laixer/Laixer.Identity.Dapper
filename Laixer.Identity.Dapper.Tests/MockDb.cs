using Laixer.Identity.Dapper.Database;
using Laixer.Identity.Dapper.Internal;
using System;
using System.Data;

namespace Laixer.Identity.Dapper.Tests
{
    internal class MockDbConnection : IDbConnection
    {
        public string ConnectionString { get; set; }

        public int ConnectionTimeout => 0;

        public string Database => string.Empty;

        public ConnectionState State => ConnectionState.Open;

        public IDbTransaction BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public IDbTransaction BeginTransaction(IsolationLevel il)
        {
            throw new NotImplementedException();
        }

        public void ChangeDatabase(string databaseName)
        {

        }

        public void Close() => Dispose();

        public IDbCommand CreateCommand()
        {
            throw new NotImplementedException();
        }

        public void Dispose() { }

        public void Open() { }
    }

    internal class MockDb : IDatabaseDriver
    {
        public IQueryRepository QueryRepository { get; }

        public IDbConnection GetDbConnection() => _db;

        private readonly IDbConnection _db;

        public MockDb(IDbConnection db)
        {
            QueryRepository = new DefaultQueryRepository();

            _db = db;
        }
    }
}
