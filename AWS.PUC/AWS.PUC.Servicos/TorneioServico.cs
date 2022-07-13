using AWS.PUC.Modelos;
using AWS.PUC.Repositorio;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AWS.PUC.Servicos
{
    public class TorneioServico : ITorneioServico
    {
        private readonly IGenericRepository<Torneio> _torneioRepositorio;
        private readonly IGenericRepository<TorneioPartida> _torneiosPartidasRepositorio;

        public TorneioServico(IGenericRepository<Torneio> torneioRepositorio, IGenericRepository<TorneioPartida> torneiosPartidasRepositorio)
        {
            _torneioRepositorio = torneioRepositorio;
            _torneiosPartidasRepositorio = torneiosPartidasRepositorio;
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
        public async Task AssociarTorneioPartida(Guid torneioId, Guid partidaId)
        {
            var associacaoJaExistente = _torneiosPartidasRepositorio.Exist(x => x.TorneioId == torneioId && x.PartidaId == partidaId);

            if (associacaoJaExistente)
            {
                throw new Exception("Já existe a associação entre o torneio e a partida");
            }

            TorneioPartida torneioPartida = new TorneioPartida(Guid.NewGuid(), torneioId, partidaId);
            await _torneiosPartidasRepositorio.AddAsync(torneioPartida);
        }
        public async Task EditarAssociacaoTorneioPartida(Guid id, Guid torneioId, Guid partidaId)
        {
            TorneioPartida torneioPartida = await _torneiosPartidasRepositorio.FindAsync(x => x.Id == id);

            if (torneioPartida == null)
            {
                throw new Exception("Registro não encontrado");
            }

            TorneioPartida associacaoJaExistente = await _torneiosPartidasRepositorio.FindAsync(x => x.TorneioId == torneioId && x.PartidaId == partidaId);

            if (associacaoJaExistente != null && associacaoJaExistente.Id != id)
            {
                throw new Exception("Já existe a associação entre o torneio e a partida");
            }

            torneioPartida.SetPartidaId(partidaId);

            await _torneiosPartidasRepositorio.UpdateAsync(torneioPartida);
        }
    }
}
