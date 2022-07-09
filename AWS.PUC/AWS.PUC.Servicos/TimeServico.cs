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
        public Task Cadastrar(Time entidade)
        {
            throw new NotImplementedException();
        }

        public async Task Editar(Time entidade)
        {
            throw new NotImplementedException();
        }

        public async Task Excluir(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Time>> Listar()
        {
            ////Todo mock inicial: Código definitivo a Iplementar 
            //List<Time> times = new List<Time>();

            //times.Add(new Time(Guid.Parse("d7a5edda-0808-47a9-ad22-38b08cc6d662"), "Cruzeiro", "Belo Horizonte-MG"));
            //times.Add(new Time(Guid.Parse("78e4bd84-8c0c-4492-a927-ce12b70a7cf8"), "Atletico", "Belo Horizonte-MG"));
            //times.Add(new Time(Guid.Parse("3fc9cb4e-0bbf-4011-a6e3-df5c71e46056"), "America", "Belo Horizonte-MG"));

            //return times;

            return await _timeRepositorio.GetAllAsync();
        }

        public async Task<Time> Obter(Guid id)
        {
            return await _timeRepositorio.GetByIdAsync(id);
        }
    }
}
