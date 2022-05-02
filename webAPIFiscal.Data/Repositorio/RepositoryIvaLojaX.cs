
using System.Linq;
using System;
using WebApiFiscal.Dominio.Model;
using WebApiFiscal.Data.Context;
using WebApiFiscal.Dominio.Contracts.Repositorios;

namespace WebApiFiscal.Data.Repositorio
{
    public class RepositoryIvaLojaX: RepositoryBase<TblIvaLojaX>, IIVALojaRepositorio
    {
        private readonly SqlwebbsyssigeContext contexto;

        public RepositoryIvaLojaX()
        {
            contexto = new SqlwebbsyssigeContext();
        }

        public TblIvaLojaX BuscarIVALoja(string CEST, string NCM, string EmitenteUF, string DestinatarioUF)
        {
            try
            {
                string _cest = CEST;
                if (_cest != "CE")
                {
                    var _ivaLoja = contexto.TblIvaLojaX.FirstOrDefault(iva => iva.Tec == NCM
                                                               && iva.Sigla == EmitenteUF
                                                               && iva.SiglaDestino == DestinatarioUF
                                                               && iva.Cest == CEST
                                                               && iva.Data1 <= DateTime.Now
                                                               && iva.Data2 >= DateTime.Now);
                    return _ivaLoja;

                }
                else
                {
                    var _ivaLoja = contexto.TblIvaLojaX.FirstOrDefault(iva => iva.Tec == NCM
                                                                 && iva.Sigla == EmitenteUF
                                                                 && iva.SiglaDestino == DestinatarioUF
                                                                 && iva.Data1 <= DateTime.Now
                                                                 && iva.Data2 >= DateTime.Now);
                    return _ivaLoja;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao tentar consultar tabela IVALoja! - "+ex.Message);
            }

           
            



           
        }


    }
}
