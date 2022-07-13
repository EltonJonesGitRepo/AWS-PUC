using AWS.PUC.DTO;
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
        public async Task AssociarTorneioPartida(TorneioPartidaInputDTO torneioPartidaInputDTO)
        {
            var associacaoJaExistente = _torneiosPartidasRepositorio.Exist(x => x.TorneioId == torneioPartidaInputDTO.TorneioId && x.PartidaId == torneioPartidaInputDTO.PartidaId);

            if (associacaoJaExistente)
            {
                throw new Exception("Já existe a associação entre o torneio e a partida");
            }

            TorneioPartida torneioPartida = new TorneioPartida(Guid.NewGuid(), torneioPartidaInputDTO.TorneioId, torneioPartidaInputDTO.PartidaId);
            await _torneiosPartidasRepositorio.AddAsync(torneioPartida);
        }
        public async Task EditarAssociacaoTorneioPartida(TorneioPartidaInputDTO torneioPartidaInputDTO)
        {
            TorneioPartida torneioPartida = await _torneiosPartidasRepositorio.FindAsync(x => x.Id == torneioPartidaInputDTO.Id);

            if (torneioPartida == null)
            {
                throw new Exception("Registro não encontrado");
            }

            TorneioPartida associacaoJaExistente = await _torneiosPartidasRepositorio.FindAsync(x => x.TorneioId == torneioPartidaInputDTO.TorneioId && x.PartidaId == torneioPartidaInputDTO.PartidaId);

            if (associacaoJaExistente != null && associacaoJaExistente.Id != torneioPartidaInputDTO.Id)
            {
                throw new Exception("Já existe a associação entre o torneio e a partida");
            }

            torneioPartida.SetPartidaId(torneioPartidaInputDTO.PartidaId);

            await _torneiosPartidasRepositorio.UpdateAsync(torneioPartida);
        }
    }
}
