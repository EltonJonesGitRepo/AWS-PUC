using AWS.PUC.Modelos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AWS.PUC.Servicos
{
    public interface ITimeServico
    {
        Task<Time> Obter(Guid id);
        Task<ICollection<Time>> Listar();
        Task Cadastrar(Time entidade);
        Task Editar(Time entidade);
        Task Excluir(Guid id);
    }
}
