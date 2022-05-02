
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Linq;
using WebApiFiscal.Data.Context;
using WebApiFiscal.Dominio.Contracts.Repositorios;
using WebApiFiscal.Dominio.Model;

namespace WebApiFiscal.Data.Repositorio
{
    public class RepositoryEmpresa : RepositoryBase<TblEmpresa>, IEmpresaRepositorio
    {
        
        private readonly SqlwebbsyssigeContext contexto;


        public RepositoryEmpresa()
        {
            contexto =  new SqlwebbsyssigeContext();    
        }
        
        
        public TblEmpresa BuscaEmpresaCGC(string CGC)
        {
            try
            {
                var CNPJ = Convert.ToUInt64(CGC).ToString(@"00\.000\.000\/0000\-00");
                var empresa = contexto
                   .TblEmpresa
                   .FirstOrDefault(empresa => empresa.Cgc == CNPJ);

                if(empresa == null)
                {
                    
                    throw new Exception("Erro ao tentar encontrar empresa pelo CNPJ infomado! - ");
                }
                else
                {
                    return empresa;
                }

               

            }
            catch(Exception ex)
            {
                throw new Exception("Erro ao tentar encontrar empresa pelo CNPJ infomado! - " + ex.Message);
            }

            
        }


    }
    
}
