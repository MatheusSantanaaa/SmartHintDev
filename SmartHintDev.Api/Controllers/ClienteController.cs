using Microsoft.AspNetCore.Mvc;
using SmartHintDev.Domain.Core.Extensions;
using SmartHintDev.Domain.Dtos;
using SmartHintDev.Domain.Interfaces;
using SmartHintDev.Domain.Models;

namespace SmartHintDev.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ApiController
    {
        private readonly IClienteAppService _clienteAppService;

        public ClienteController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar([FromBody] RegistrarClienteDto clienteDto)
        {
            try
            {
                if(!ModelState.IsValid) return BadRequest(ModelState);

                return CustomResponse(await _clienteAppService.Registrar(clienteDto));
            }
            catch (SystemContextException ex)
            {
                AdicionarMensagemErro(ex.Errors);
                return CustomResponse();
            }
            catch (Exception ex)
            {
                AdicionarMensagemErro(ex.Message);
                return CustomResponse();
            }
        }

        [HttpPut("atualizar")]
        public async Task<IActionResult> Atualizar([FromBody] AtualizarClienteDto clienteDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);


                return CustomResponse(await _clienteAppService.Atualizar(clienteDto));
            }
            catch (SystemContextException ex)
            {
                AdicionarMensagemErro(ex.Errors);
                return CustomResponse();
            }
            catch (Exception ex)
            {
                AdicionarMensagemErro(ex.Message);
                return CustomResponse();
            }
        }

        [HttpGet("obter/{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                return CustomResponse(await _clienteAppService.ObterPorId(id));
            }
            catch (SystemContextException ex)
            {
                AdicionarMensagemErro(ex.Errors);
                return CustomResponse();
            }
            catch (Exception ex)
            {
                AdicionarMensagemErro(ex.Message);
                return CustomResponse();
            }
        }

        [HttpGet("obter-listagem")]
        public async Task<IActionResult> Get()
        {
            try
            {
                return CustomResponse(await _clienteAppService.ObterLista());
            }
            catch (SystemContextException ex)
            {
                AdicionarMensagemErro(ex.Errors);
                return CustomResponse();
            }
            catch (Exception ex)
            {
                AdicionarMensagemErro(ex.Message);
                return CustomResponse();
            }
        }

        [HttpGet("obter-filtragem")]
        public async Task<IActionResult> Get([FromQuery] FiltragemDto filtragemDto)
        {
            try
            {
                return CustomResponse(await _clienteAppService.ObterPorFiltragem(filtragemDto));
            }
            catch (SystemContextException ex)
            {
                AdicionarMensagemErro(ex.Errors);
                return CustomResponse();
            }
            catch (Exception ex)
            {
                AdicionarMensagemErro(ex.Message);
                return CustomResponse();
            }
        }
    }
}
