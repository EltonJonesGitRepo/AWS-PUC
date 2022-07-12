using AWS.PUC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS.PUC.Servicos
{
    public interface IJogadorServico
    {
        Task<Jogador> Obter(Guid id);
        Task<ICollection<Jogador>> Listar();
        Task Cadastrar(Jogador entidade);
        Task Editar(Jogador entidade);
        Task Excluir(Guid id);
    }
}
