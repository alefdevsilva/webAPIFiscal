using Microsoft.Data.SqlClient;
using System.Data;

namespace WebApiFiscal.Data.Context;

public class SimpleDbContext : IDisposable
{
    private readonly IDbConnection _dbConnection;
    private bool _disposedValue;

    protected SimpleDbContext(string stringConnection)
    {
        _dbConnection = new SqlConnection(stringConnection);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public IDbConnection GetConnection()
    {
        if (_dbConnection.State.Equals(ConnectionState.Closed))
        {
            _dbConnection.Open();
        }

        return _dbConnection ?? throw new NullReferenceException("A conexão com o banco de dados encontra-se indisponível.");
    }

    private void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                _dbConnection.Dispose();
            }
        }

        _disposedValue = true;
    }
}
