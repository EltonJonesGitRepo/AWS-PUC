using AWS.PUC.Modelos;
using AWS.PUC.Repositorio;
using AWS.PUC.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS.PUC.Servicos
{
    public class PartidaServico : IPartidaServico
    {
        private readonly IGenericRepository<Partida> _partidaRepositorio;

        public PartidaServico(IGenericRepository<Partida> partidaRepositorio)
        {
            _partidaRepositorio = partidaRepositorio;
        }

        public async Task Cadastrar(Partida entidade)
        {
            await _partidaRepositorio.AddAsync(entidade);
        }

        public async Task Editar(Partida entidade)
        {
            await _partidaRepositorio.UpdateAsync(entidade);
        }

        public async Task Excluir(Guid id)
        {
            var partida = await Obter(id);
            await _partidaRepositorio.DeleteAsync(partida);
        }

        public async Task<ICollection<Partida>> Listar()
        {
            return await _partidaRepositorio.GetAllAsync();
        }

        public async Task<Partida> Obter(Guid id)
        {
            return await _partidaRepositorio.FindAsync(x => x.Id == id);
        }
    }
}
