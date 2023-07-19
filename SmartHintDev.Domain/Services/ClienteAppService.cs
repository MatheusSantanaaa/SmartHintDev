using FluentValidation.Results;
using SmartHintDev.Domain.Core.Extensions;
using SmartHintDev.Domain.Dtos;
using SmartHintDev.Domain.Interfaces;
using SmartHintDev.Domain.Models;
using SmartHintDev.Domain.Validacao;

namespace SmartHintDev.Domain.Services
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteAppService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }


        public async Task<List<ClienteDto>> ObterLista()
        {
            var clientes = await _clienteRepository.ObterTodos();

            var clientesDto = new List<ClienteDto>();

            foreach (var cliente in clientes)
            {
                clientesDto.Add(new ClienteDto
                {
                    Bloqueado = cliente.Bloqueado,
                    CpfCnpj = cliente.CpfCnpj,
                    DataCriacao = cliente.DataCriacao,
                    DataNascimento = cliente.DataNascimento,
                    Email = cliente.Email,
                    Genero = cliente.Genero,
                    Id = cliente.Id,
                    InscricaoEstadual = cliente.InscricaoEstadual,
                    Isento = cliente.Isento,
                    Nome = cliente.Nome,
                    Senha = cliente.Senha,
                    Telefone = cliente.Telefone,
                    TipoPessoa = cliente.TipoPessoa
                });
            }

            return clientesDto;
        }

        public async Task<ClienteDto> ObterPorId(Guid id)
        {
            var clienteDto = await _clienteRepository.ObterPorId(id);

            return new ClienteDto
            {
                Bloqueado = clienteDto.Bloqueado,
                CpfCnpj = clienteDto.CpfCnpj,
                DataCriacao = clienteDto.DataCriacao,
                DataNascimento = clienteDto.DataNascimento,
                Email = clienteDto.Email,
                Genero = clienteDto.Genero,
                Id = clienteDto.Id,
                InscricaoEstadual = clienteDto.InscricaoEstadual,
                Isento = clienteDto.Isento,
                Nome = clienteDto.Nome,
                Senha = clienteDto.Senha,
                Telefone = clienteDto.Telefone,
                TipoPessoa = clienteDto.TipoPessoa
            };
        }

        public async Task<bool> Registrar(RegistrarClienteDto clienteDto)
        {
            var cliente = new Cliente(clienteDto.Nome,
                                         clienteDto.Email,
                                         clienteDto.Telefone,
                                         clienteDto.TipoPessoa,
                                         clienteDto.CpfCnpj,
                                         clienteDto.InscricaoEstadual,
                                         clienteDto.Isento,
                                         clienteDto.Genero,
                                         clienteDto.DataNascimento,
                                         clienteDto.Senha);

            var instancia = new CLienteValidacaoService();
            var validacao = instancia.Validate(cliente);

            if (!validacao.IsValid) throw new SystemContextException(validacao.Errors.Select(x => x.ErrorMessage).ToList());

            var clientes = await _clienteRepository.ObterTodos();

            if(clientes.Any(x => x.CpfCnpj.Equals(clienteDto.CpfCnpj)))
            {
                var erro = new List<string> { "Este CPF/CNPJ já está cadastrado para outro Cliente" };
                throw new SystemContextException(erro);
            }

            if (clientes.Any(x => x.Email.Equals(clienteDto.Email)))
            {
                var erro = new List<string> { "Este e-mail já está cadastrado para outro Cliente" };
                throw new SystemContextException(erro);
            }

            if (!string.IsNullOrEmpty(clienteDto.InscricaoEstadual) && clientes.Any(x => x.InscricaoEstadual.Equals(clienteDto.InscricaoEstadual)))
            {
                var erro = new List<string> { "Esta Inscrição Estadual já está cadastrada para outro Cliente" };
                throw new SystemContextException(erro);
            }

            await _clienteRepository.Adicionar(cliente);

            return true;
        }
        public async Task<bool> Atualizar(AtualizarClienteDto clienteDto)
        {
            var clienteValidacao = new Cliente(clienteDto.Nome,
                                               clienteDto.Email,
                                               clienteDto.Telefone,
                                               clienteDto.TipoPessoa,
                                               clienteDto.CpfCnpj,
                                               clienteDto.InscricaoEstadual,
                                               clienteDto.Isento,
                                               clienteDto.Genero,
                                               clienteDto.DataNascimento,
                                               clienteDto.Senha);

            var instancia = new CLienteValidacaoService();
            var validacao = instancia.Validate(clienteValidacao);

            if (!validacao.IsValid) throw new SystemContextException(validacao.Errors.Select(x => x.ErrorMessage).ToList());

            var cliente = await _clienteRepository.ObterPorId(clienteDto.Id);

            if(cliente is null)
            {
                var erro = new List<string> { "Cliente inválido ou inexistente" };
                throw new SystemContextException(erro);
            }

            cliente.Atualizar(clienteDto.Nome,
                              clienteDto.Email,
                              clienteDto.Telefone,
                              clienteDto.TipoPessoa,
                              clienteDto.CpfCnpj,
                              clienteDto.InscricaoEstadual,
                              clienteDto.Isento,
                              clienteDto.Genero,
                              clienteDto.DataNascimento,
                              clienteDto.Bloqueado,
                              clienteDto.Senha);

            await _clienteRepository.Atualizar(cliente);

            return true;

        }

        public async Task<List<ClienteDto>> ObterPorFiltragem(FiltragemDto filtragemDto)
        {
            var filtroCliente = new Cliente(filtragemDto.Nome,
                                      filtragemDto.DataCriacao,
                                      filtragemDto.Email,
                                      filtragemDto.Bloqueado,
                                      filtragemDto.Telefone);

            var clientes = await _clienteRepository.ObterPorFiltragem(filtroCliente);

            var clientesDto = new List<ClienteDto>();
            foreach (var cliente in clientes)
            {
                clientesDto.Add(new ClienteDto
                {
                    Bloqueado = cliente.Bloqueado,
                    CpfCnpj = cliente.CpfCnpj,
                    DataCriacao = cliente.DataCriacao,
                    DataNascimento = cliente.DataNascimento,
                    Email = cliente.Email,
                    Genero = cliente.Genero,
                    Id = cliente.Id,
                    InscricaoEstadual = cliente.InscricaoEstadual,
                    Isento = cliente.Isento,
                    Nome = cliente.Nome,
                    Senha = cliente.Senha,
                    Telefone = cliente.Telefone,
                    TipoPessoa = cliente.TipoPessoa
                });
            }

            return clientesDto;
        }
    }
}
