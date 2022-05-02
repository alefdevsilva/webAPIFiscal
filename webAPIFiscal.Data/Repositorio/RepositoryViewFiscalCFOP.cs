
using System.Linq;
using WebApiFiscal.Data.Context;
using WebApiFiscal.Data.Repositorio;
using WebApiFiscal.Dominio.Contracts.Repositorios;
using WebApiFiscal.Dominio.Model;

namespace APIOmni.Repositories
{
    public class RepositoryViewFiscalCFOP: RepositoryBase<Fiscalcfopview>, IFiscalCFOPRepositorio
    {
        private readonly SqlwebbsyssigeContext contexto;

        public RepositoryViewFiscalCFOP()
        {
            contexto = new SqlwebbsyssigeContext();
        }

        public Fiscalcfopview BuscarCFOP(string CLAFISCAL)
        {
            try
            {
                var cfop = contexto.Fiscalcfopview.FirstOrDefault(clafiscal => clafiscal.Clafiscal == CLAFISCAL);
                return cfop;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao tentar consultar tabela de CFOP - " + ex.Message);
            }

        }

    }
}
