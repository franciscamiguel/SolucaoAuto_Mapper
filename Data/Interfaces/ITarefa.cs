using Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface ITarefa : IGeneric<Tarefa>
    {
        Task AdicionarTarefa(Tarefa objeto);
        Task<Tarefa> BuscarTarefa(int Id);
        Task<List<Tarefa>> ListarTarefas();
    }
}
