using WebApiFiscal.Dominio.Model;

namespace WebApiFiscal.Dominio.Contracts.Repositorios;

public interface IFiscalCFOPRepositorio
{
    public Fiscalcfopview BuscarCFOP(string CLAFISCAL);

}
