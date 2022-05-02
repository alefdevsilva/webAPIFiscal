using WebApiFiscal.Dominio.Model;

namespace WebApiFiscal.Dominio.Contracts.Repositorios;

public interface IFiscalNCM
{
    public FiscalncmMonofasico BuscarFiscalNCMMonofasico(string NCM);

}
