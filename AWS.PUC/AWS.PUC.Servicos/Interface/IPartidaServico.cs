using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AWS.PUC.Modelos;

namespace AWS.PUC.Servicos
{
    public interface IPartidaServico
    {
        Task<Partida> Obter(Guid id);
        Task<ICollection<Partida>> Listar();
        Task Cadastrar(Partida entidade);
        Task Editar(Partida entidade);
        Task Excluir(Guid id);
    }
}
