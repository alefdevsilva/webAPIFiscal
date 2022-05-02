
using System.Linq;
using WebApiFiscal.Data.Context;
using WebApiFiscal.Dominio.Contracts.Repositorios;
using WebApiFiscal.Dominio.Model;

namespace WebApiFiscal.Data.Repositorio
{
    public class RepositoryRCT:RepositoryBase<ViewProdutoGeralNomesAntigosComCodBarras>, IProdutoRepositorio
    {
        private readonly SqlwebbsyssigeContext contexto;

        public RepositoryRCT()
        {
            contexto = new SqlwebbsyssigeContext();
        }

        public ViewProdutoGeralNomesAntigosComCodBarras BuscarRCT(string RCT)
        {
            try
            {
                var _rct = contexto.ViewProdutoGeralNomesAntigosComCodBarras.
                                                            FirstOrDefault(rct =>
                                                                           rct.Rctl == RCT);

                if(_rct == null)
                {
                    throw new Exception("Erro ao tentar consultar tabela de Produtos");
                }
                else
                {
                    return _rct;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao tentar consultar tabela de Produtos - "+ex.Message);
            }

            
        }


    }
}
