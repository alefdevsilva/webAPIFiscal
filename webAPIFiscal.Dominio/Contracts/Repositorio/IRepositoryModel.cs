using System.Collections.Generic;

namespace WebApiFiscal.Dominio.Contracts.Repositorios
{
    public interface IRepositoryModel<T> where T : class
    {
        T Selecionar(params object[] variavel);

        List<T> SelecionarTodos();

        void SavesChanges();
    }
}
