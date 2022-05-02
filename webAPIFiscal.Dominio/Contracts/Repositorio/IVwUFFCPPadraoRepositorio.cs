using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiFiscal.Dominio.Model;

namespace WebApiFiscal.Dominio.Contracts.Repositorios;

public  interface IVwUFFCPPadraoRepositorio: IRepositoryModel<VwUfFcppadrao>
{
    public VwUfFcppadrao BuscarUFFCPPadrao(string UF);
    


}
