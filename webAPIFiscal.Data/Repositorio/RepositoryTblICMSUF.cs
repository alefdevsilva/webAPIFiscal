using System.Linq;
using System;
using WebApiFiscal.Data.Context;
using WebApiFiscal.Dominio.Model;
using WebApiFiscal.Dominio.Contracts.Repositorios;

namespace WebApiFiscal.Data.Repositorio
{
    public class RepositoryTblICMSUF : RepositoryBase<RepositoryTblICMSUF>, ITblICMSRepositorio
    {
        private readonly SqlwebbsyssigeContext contexto;
        public RepositoryTblICMSUF()
        {
            contexto = new SqlwebbsyssigeContext();
        }


        public TblIcmsUf BuscarICMSUF(string UFOrigem, string UFDestino)
        {
            try
            {
                var ICMSUF = contexto.TblIcmsUf.FirstOrDefault(icms =>
                                                            icms.UfOrigem == UFOrigem
                                                            && icms.UfDestino == UFDestino
                                                            && DateTime.Now >= icms.DataInicio
                                                            && DateTime.Now <= icms.DataTermino);


                if (ICMSUF == null)
                {
                    throw new Exception("Erro ao tentar consultar tabela de ICMSUF");
                }
                else
                {
                    return ICMSUF;
                }

             

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao tentar consultar tabela de ICMSUF - " + ex.Message);
            }

            
        }
    }
}
