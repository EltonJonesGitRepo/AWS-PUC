using AWS.PUC.Modelos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AWS.PUC.Servicos
{
    public interface ITransferenciaServico
    {
        Task<Transferencia> Obter(Guid id);
        Task<ICollection<Transferencia>> Listar();
        Task Cadastrar(Transferencia entidade);
        Task Editar(Transferencia entidade);
    }
}
