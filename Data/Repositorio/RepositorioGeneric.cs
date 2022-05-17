using Data.Config;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    public class RepositorioGeneric<T> : IGeneric<T>, IDisposable where T : class
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;
             
        public RepositorioGeneric() // Construtor da minha class . Inicializa as variaveis
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();
        }
        public async Task Adicionar(T obj)
        {
            using (var data = new ContextBase(_optionsBuilder))
            {
                await data.Set<T>().AddAsync(obj);
                await data.SaveChangesAsync();
            }
        }

        public async Task Atualizar(T obj)
        {
            using (var data = new ContextBase(_optionsBuilder))
            {
                 data.Set<T>().Update(obj);
                await data.SaveChangesAsync();
            }
        }

        public async Task<T> BuscarCodigo(int Id)
        {
            using (var data = new ContextBase(_optionsBuilder))
            {
                return await data.Set<T>().FindAsync(Id);
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task Excluir(T obj)
        {
            using (var data = new ContextBase(_optionsBuilder))
            {
                data.Set<T>().Remove(obj);
                await data.SaveChangesAsync();
            }
        }

        public async Task<List<T>> ListarTudo()
        {
            using (var data = new ContextBase(_optionsBuilder))
            {
                return await data.Set<T>().AsNoTracking().ToListAsync();
            }
        }

    }
}
