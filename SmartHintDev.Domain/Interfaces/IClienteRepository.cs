using SmartHintDev.Domain.Models;

namespace SmartHintDev.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task Adicionar(Cliente cliente);
        Task<Cliente> ObterPorId(Guid id);
        Task<List<Cliente>> ObterTodos();
        Task<List<Cliente>> ObterPorFiltragem(Cliente cliente);
        Task Atualizar(Cliente cliente);
        Task Remover(Cliente cliente);
        Task<int> SaveChanges();
    }
}
