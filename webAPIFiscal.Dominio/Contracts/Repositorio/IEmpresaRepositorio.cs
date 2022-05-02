using WebApiFiscal.Dominio.Model;

namespace WebApiFiscal.Dominio.Contracts.Repositorios
{
    public interface IEmpresaRepositorio:IRepositoryModel<TblEmpresa>
    {
        public TblEmpresa BuscaEmpresaCGC(string CGC);

    }
}
