using LinqKit;
using Microsoft.EntityFrameworkCore;
using SmartHintDev.Domain.Core.Utils;
using SmartHintDev.Domain.Interfaces;
using SmartHintDev.Domain.Models;
using SmartHintDev.Infra.Context;

namespace SmartHintDev.Infra.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly SmartHintDevContext _context;
        public ClienteRepository(SmartHintDevContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Adicionar(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await SaveChanges();
        }

        public async Task Atualizar(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await SaveChanges();
        }

        public async Task<List<Cliente>> ObterPorFiltragem(Cliente cliente)
        {
            var predicate = PredicateBuilder.New<Cliente>(true);

            if (!string.IsNullOrEmpty(cliente.Nome))
                predicate = predicate.And(p => p.Nome.Contains(cliente.Nome));

            if(!string.IsNullOrEmpty(cliente.Email))
                predicate = predicate.And(p => p.Email.Contains(cliente.Email));

            if (!string.IsNullOrEmpty(cliente.Telefone))
                predicate = predicate.And(p => p.Telefone.Contains(cliente.Telefone));

            if (cliente.Bloqueado != null)
                predicate = predicate.And(p => p.Bloqueado == cliente.Bloqueado);

            if (cliente.DataCriacao != DateTime.MinValue)
                predicate = predicate.And(p => p.DataCriacao.Date <= cliente.DataCriacao.Date);

            return await _context.Clientes.AsNoTracking().Where(predicate).ApplyPaging(1, 20).ToListAsync();

        }

        public async Task<Cliente> ObterPorId(Guid id)
        {
            return await _context.Clientes.AsNoTracking().FirstAsync(x => x.Id == id);
        }

        public async Task<List<Cliente>> ObterTodos()
        {
            return await _context.Clientes.AsNoTracking().ToListAsync();
        }

        public async Task Remover(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync(); 
        }

    }
}
