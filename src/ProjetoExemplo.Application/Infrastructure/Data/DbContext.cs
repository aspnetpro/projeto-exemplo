using Microsoft.Data.SqlClient;
using System.Data;

namespace ProjetoExemplo.Application.Infrastructure.Data;

public interface IDbContext
{
    IDbConnection Connection { get; }
}

public class MssqlDbContext : IDbContext
{
    private readonly string connString;

    public MssqlDbContext(string connString)
    {
        this.connString = connString;
    }

    public IDbConnection Connection
    {
        get
        {
            var sqlConn = new SqlConnection(connString);
            sqlConn.Open();
            return sqlConn;
        }
    }
}
