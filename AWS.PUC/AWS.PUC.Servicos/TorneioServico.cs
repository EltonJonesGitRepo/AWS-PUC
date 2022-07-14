using AWS.PUC.COMUM.Enumeradores;
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
        public readonly IPartidaServico _partidaServico;

        public TorneioServico(IGenericRepository<Torneio> torneioRepositorio, 
            IGenericRepository<TorneioPartida> torneiosPartidasRepositorio,
            IPartidaServico partidaServico)
        {
            _torneioRepositorio = torneioRepositorio;
            _torneiosPartidasRepositorio = torneiosPartidasRepositorio;
            _partidaServico = partidaServico;
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

        public async Task InicarPartida(Guid idPartida)
        {
            Partida partida = await _partidaServico.Obter(idPartida);

            partida.IniciarPartida();

            await _partidaServico.Editar(partida);
        }

        public async Task CadastrarGol(Guid idPartida, TipoGolEnum tipoGol)
        {
            Partida partida = await _partidaServico.Obter(idPartida);

            partida.MarcarGol(tipoGol == TipoGolEnum.GolMandante);

            await _partidaServico.Editar(partida);
        }

        public async Task CadastrarIntervalo(Guid idPartida)
        {
            Partida partida = await _partidaServico.Obter(idPartida);

            if (!partida.DataInicioIntervalo.HasValue)
            {
                partida.IniciarIntervalo();
            }
            else
            {
                partida.EncerrarIntervalo();
            }
            
            await _partidaServico.Editar(partida);
        }

        public async Task CadastrarAcrescimo(Guid idPartida, int acrescimoEmMinutos)
        {
            Partida partida = await _partidaServico.Obter(idPartida);

            partida.Acrescimo(!partida.AcrescimoEtapaInicial.HasValue, acrescimoEmMinutos);

            await _partidaServico.Editar(partida);
        }

        public async Task CadastrarSubstituicao(Guid idPartida)
        {
            Partida partida = await _partidaServico.Obter(idPartida);

            partida.IncrementarSubstituicoes();

            await _partidaServico.Editar(partida);
        }

        public async Task CadastrarAdvertencia(Guid idPartida)
        {
            Partida partida = await _partidaServico.Obter(idPartida);

            partida.IncrementarAdvertencia();

            await _partidaServico.Editar(partida);
        }

        public async Task EncerrarPartida(Guid idPartida)
        {
            Partida partida = await _partidaServico.Obter(idPartida);

            partida.EncerrarPartida();

            await _partidaServico.Editar(partida);
        }
    }
}
