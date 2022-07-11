using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AWS.PUC.Modelos;

namespace AWS.PUC.Servicos
{
    public interface ITorneioServico
    {
        Task<Torneio> Obter(Guid id);
        Task<ICollection<Torneio>> Listar();
        Task Cadastrar(Torneio entidade);
        Task Editar(Torneio entidade);
        Task Excluir(Guid id);
    }
}
