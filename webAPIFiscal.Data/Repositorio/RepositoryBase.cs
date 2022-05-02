using System;
using System.Collections.Generic;
using System.Linq;
using WebApiFiscal.Data.Context;
using WebApiFiscal.Dominio.Contracts.Repositorios;
using WebApiFiscal.Dominio.Model;

namespace WebApiFiscal.Data.Repositorio
{
    public class RepositoryBase<T> : IRepositoryModel<T>, IDisposable where T : class
    {
        protected SqlwebbsyssigeContext _contexto;

        public RepositoryBase()
        {
                _contexto = new SqlwebbsyssigeContext();
        }

        public void Dispose()
        {
           // throw new NotImplementedException();  //Implementar Disposeble
        }

        public void SavesChanges()
        {
            throw new NotImplementedException();
        }

        public T Selecionar(params object[] variavel)
        {
            return _contexto.Set<T>().Find(variavel);  
        }

        public List<T> SelecionarTodos()
        {
            return _contexto.Set<T>().ToList();
        }
    }
}
