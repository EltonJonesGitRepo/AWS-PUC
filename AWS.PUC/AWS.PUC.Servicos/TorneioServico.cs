using AWS.PUC.Modelos;
using AWS.PUC.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS.PUC.Servicos
{
    public class TorneioServico : ITorneioServico
    {
        private readonly IGenericRepository<Torneio> _torneioRepositorio;

        public TorneioServico(IGenericRepository<Torneio> torneioRepositorio)
        {
            _torneioRepositorio = torneioRepositorio;
        }

        public async Task Cadastrar(Torneio entidade)
        {
            await _torneioRepositorio.AddAsync(entidade);
        }

        public async Task Editar(Torneio entidade)
        {
            await _torneioRepositorio.UpdateAsync(entidade);
        }

        public async Task Excluir(Guid id)
        {
            var torneio = await Obter(id);
            await _torneioRepositorio.DeleteAsync(torneio);
        }

        public async Task<ICollection<Torneio>> Listar()
        {
            return await _torneioRepositorio.GetAllAsync();
        }

        public async Task<Torneio> Obter(Guid id)
        {
            return await _torneioRepositorio.GetByIdAsync(id);
        }
    }
}
