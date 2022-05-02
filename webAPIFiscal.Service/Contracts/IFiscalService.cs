using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebApiFiscal.Dominio.Model;

namespace WebApiFiscal.Service.Contracts
{
    public interface IFiscalService
    {
        Task<IEnumerable<FiscalCfop>> ListarCFOPS(string cfop);

        public dadosOmni BuscarDadosFiscais(string CGC, string UF, string Operacao, string RCT);

        Task<byte[]> GetDanfeXML(string chaveacesso);
    }
}
