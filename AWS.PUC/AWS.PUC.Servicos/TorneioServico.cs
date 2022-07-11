using AWS.PUC.Modelos;
using AWS.PUC.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS.PUC.Servicos
{
    public class TorneioServico : ITorneioServico
    {
        private readonly IGenericRepository<Torneio> _torneioRepositorio;

        public TorneioServico(IGenericRepository<Torneio> torneioRepositorio)
        {
            _torneioRepositorio = torneioRepositorio;
        }

        public Task Cadastrar(Torneio entidade)
        {
            throw new NotImplementedException();
        }

        public Task Editar(Torneio entidade)
        {
            throw new NotImplementedException();
        }

        public Task Excluir(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Torneio>> Listar()
        {
            return await _torneioRepositorio.GetAllAsync();
        }

        public async Task<Torneio> Obter(Guid id)
        {
            return await _torneioRepositorio.GetByIdAsync(id);
        }
    }
}
