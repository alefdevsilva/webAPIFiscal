using System.Linq;
using WebApiFiscal.Data.Context;
using WebApiFiscal.Dominio.Contracts.Repositorios;
using WebApiFiscal.Dominio.Model;

namespace WebApiFiscal.Data.Repositorio
{
    public class RepositoryFiscalncmMonofasico: IFiscalNCM
    {
        private readonly SqlwebbsyssigeContext contexto;

        public RepositoryFiscalncmMonofasico()
        {
            contexto = new SqlwebbsyssigeContext();
        }

        public FiscalncmMonofasico BuscarFiscalNCMMonofasico(string NCM)
        {
            try
            {
                var fiscalNCMMonofasico = contexto.FiscalncmMonofasico.FirstOrDefault(fiscalMono => fiscalMono.Tec == NCM);

                return fiscalNCMMonofasico;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao tentar consultar tabela fiscal NCM - "+ex.Message);
            }

            
        }
    }
}
