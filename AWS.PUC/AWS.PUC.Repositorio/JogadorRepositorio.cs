using AWS.PUC.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AWS.PUC.Repositorio
{    
    public class JogadorRepositorio : IJogadorRepositorio
    {

        public readonly ApplicationDbContext  _contexto;

        public JogadorRepositorio(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<Jogador> AddAsync(Jogador entity)
        {
            _contexto.Entry(entity).State = EntityState.Added;
            await _contexto.Jogadores.AddAsync(entity);
            await _contexto.SaveChangesAsync();

            return entity;
            
        }

        public async Task<int> DeleteAsync(Jogador t)
        {
            Jogador jogador = await GetByIdAsync(t.Id);
            _contexto.Remove(jogador);

            return await _contexto.SaveChangesAsync();            
        }

        public async Task<ICollection<Jogador>> GetAllAsync()
        {
            return await _contexto.Jogadores.Include(x => x.Time).ToListAsync();
        }

        public async Task<Jogador> GetByIdAsync(Guid id)
        {
            return await _contexto.Jogadores.FindAsync(id);
        }

        public async Task UpdateAsync(Jogador updated)
        {
            _contexto.Entry(updated).State = EntityState.Modified;
            await _contexto.SaveChangesAsync();
        }
    }
}
