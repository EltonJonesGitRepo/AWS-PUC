using AWS.PUC.COMUM.Enumeradores;
using AWS.PUC.DTO;
using AWS.PUC.Modelos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AWS.PUC.Servicos
{
    public interface ITorneioServico
    {
        Task<Torneio> Obter(Guid id);
        Task<ICollection<Torneio>> Listar();
        Task Cadastrar(Torneio entidade);
        Task Editar(Torneio entidade);
        Task Excluir(Guid id);
        Task AssociarTorneioPartida(TorneioPartidaInputDTO torneioPartidaInputDTO);
        Task EditarAssociacaoTorneioPartida(TorneioPartidaInputDTO torneioPartidaInputDTO);
        Task InicarPartida(Guid idPartida);
        Task CadastrarGol(Guid idPartida, TipoGolEnum tipoGol);
        Task CadastrarIntervalo(Guid idPartida);
        Task CadastrarAcrescimo(Guid idPartida, int acrescimoEmMinutos);
        Task CadastrarSubstituicao(Guid idPartida);
        Task CadastrarAdvertencia(Guid idPartida);
        Task EncerrarPartida(Guid idPartida);
    }
}
