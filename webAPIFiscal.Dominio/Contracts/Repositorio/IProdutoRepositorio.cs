using WebApiFiscal.Dominio.Model;

namespace WebApiFiscal.Dominio.Contracts.Repositorios;

public interface IProdutoRepositorio
{
    public ViewProdutoGeralNomesAntigosComCodBarras BuscarRCT(string RCT);

}
