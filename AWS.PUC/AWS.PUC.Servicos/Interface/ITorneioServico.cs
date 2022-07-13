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
        Task AssociarTorneioPartida(Guid torneioId, Guid partidaId);
        Task EditarAssociacaoTorneioPartida(Guid id, Guid torneioId, Guid partidaId);
    }
}
