using AWS.PUC.Modelos;
using AWS.PUC.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS.PUC.Servicos
{    
    public class TimeServico : ITimeServico
    {
        private readonly IGenericRepository<Time> _timeRepositorio;

        public TimeServico(IGenericRepository<Time> timeRepositorio)
        {
            _timeRepositorio = timeRepositorio;
        }
        public async Task Cadastrar(Time entidade)
        {
            await _timeRepositorio.AddAsync(entidade);
        }

        public async Task Editar(Time entidade)
        {
            await _timeRepositorio.UpdateAsync(entidade);
        }

        public async Task Excluir(Guid id)
        {
            var time = await Obter(id);
            await _timeRepositorio.DeleteAsync(time);
        }

        public async Task<ICollection<Time>> Listar()
        {
            return await _timeRepositorio.GetAllAsync();
        }

        public async Task<Time> Obter(Guid id)
        {
            return await _timeRepositorio.GetByIdAsync(id);
        }
    }
}
