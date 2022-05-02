using WebApiFiscal.Dominio.Model;

namespace WebApiFiscal.Dominio.Contracts.Repositorios;

public interface IFiscalRepositorio
{
    Task<IEnumerable<FiscalCfop>> ListarCfops(string cfop);

    string GetXmlNFE(string chaveacesso);
}
