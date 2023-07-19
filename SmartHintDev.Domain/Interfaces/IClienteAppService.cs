using SmartHintDev.Domain.Dtos;
using SmartHintDev.Domain.Models;

namespace SmartHintDev.Domain.Interfaces
{
    public interface IClienteAppService
    {
        Task<bool> Registrar(RegistrarClienteDto clienteDto);
        Task<bool> Atualizar(AtualizarClienteDto clienteDto);
        Task<List<ClienteDto>> ObterLista();
        Task<ClienteDto> ObterPorId(Guid id);
        Task<List<ClienteDto>> ObterPorFiltragem(FiltragemDto filtragemDto);
    }
}
