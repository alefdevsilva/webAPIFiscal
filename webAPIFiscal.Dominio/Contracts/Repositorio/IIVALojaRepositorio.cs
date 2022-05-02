using WebApiFiscal.Dominio.Model;

namespace WebApiFiscal.Dominio.Contracts.Repositorios;

public interface IIVALojaRepositorio
{
    public TblIvaLojaX BuscarIVALoja(string CEST, string NCM, string EmitenteUF, string DestinatarioUF);

}
