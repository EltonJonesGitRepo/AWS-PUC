using AWS.PUC.Modelos;
using AWS.PUC.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS.PUC.Servicos
{
    public class PartidaServico : IPartidaServico
    {
        public Task Cadastrar(Partida entidade)
        {
            throw new NotImplementedException();
        }

        public Task Editar(Partida entidade)
        {
            throw new NotImplementedException();
        }

        public Task Excluir(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Partida>> Listar()
        {
            throw new NotImplementedException();
        }

        public Task<Partida> Obter(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
