using AWS.PUC.Modelos;
using AWS.PUC.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS.PUC.Servicos
{
    public class TransferenciaServico : ITransferenciaServico
    {

        private readonly IGenericRepository<Transferencia> _transferenciaRepositorio;
        public readonly IJogadorServico _jogadorServico;

        public TransferenciaServico(IGenericRepository<Transferencia> transferenciaRepositorio, IJogadorServico jogadorServico)
        {
            _transferenciaRepositorio = transferenciaRepositorio;
            _jogadorServico = jogadorServico;
        }

        public async Task Cadastrar(Transferencia entidade)
        {
            Jogador jogador = await _jogadorServico.Obter(entidade.JogadorId);

            if(jogador == null)
            {
                throw new Exception("Jogador não encotrado.");
            }

            jogador.SetIdTimeDestino(entidade.IdTimeDestino);

            await _jogadorServico.Editar(jogador);

            await _transferenciaRepositorio.AddAsync(entidade);
        }

        public async Task Editar(Transferencia entidade)
        {
            Jogador jogador = await _jogadorServico.Obter(entidade.JogadorId);

            if (jogador == null)
            {
                throw new Exception("Jogador não encotrado.");
            }

            jogador.SetIdTimeDestino(entidade.IdTimeDestino);

            await _jogadorServico.Editar(jogador);

            await _transferenciaRepositorio.UpdateAsync(entidade);
        }

        public async Task<ICollection<Transferencia>> Listar()
        {
            return await _transferenciaRepositorio.GetAllAsync();
        }

        public async Task<Transferencia> Obter(Guid id)
        {
            return await _transferenciaRepositorio.GetByIdAsync(id);
        }
    }
}
