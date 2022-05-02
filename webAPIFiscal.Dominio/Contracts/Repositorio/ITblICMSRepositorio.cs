using WebApiFiscal.Dominio.Model;

namespace WebApiFiscal.Dominio.Contracts.Repositorios;

public interface ITblICMSRepositorio
{
    public TblIcmsUf BuscarICMSUF(string UFOrigem, string UFDestino);
}
