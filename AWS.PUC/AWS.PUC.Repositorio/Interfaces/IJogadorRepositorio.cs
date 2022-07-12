using AWS.PUC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS.PUC.Repositorio
{
    public interface IJogadorRepositorio
   {
        Task<ICollection<Jogador>> GetAllAsync();
        Task<Jogador> GetByIdAsync(Guid id);
        Task<Jogador> AddAsync(Jogador entity);
        Task<int> DeleteAsync(Jogador t);
        Task UpdateAsync(Jogador updated);

    }
}
