using AWS.PUC.Modelos;
using AWS.PUC.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS.PUC.Servicos
{
    public class JogadorServico : IJogadorServico
    {
        private readonly IJogadorRepositorio _jogadorRepositorio;

        public JogadorServico(IJogadorRepositorio jogadorRepositorio)
        {
            _jogadorRepositorio = jogadorRepositorio;
        }
        public async Task Cadastrar(Jogador entidade)
        {
            await _jogadorRepositorio.AddAsync(entidade);
        }

        public async Task Editar(Jogador entidade)
        {
            await _jogadorRepositorio.UpdateAsync(entidade);
        }

        public async Task Excluir(Guid id)
        {
            Jogador jogador = await Obter(id);
            await _jogadorRepositorio.DeleteAsync(jogador);            
        }

        public async Task<ICollection<Jogador>> Listar()
        {
            return await _jogadorRepositorio.GetAllAsync();
        }

        public async Task<Jogador> Obter(Guid id)
        {
            return await _jogadorRepositorio.GetByIdAsync(id);
        }
    }
}
