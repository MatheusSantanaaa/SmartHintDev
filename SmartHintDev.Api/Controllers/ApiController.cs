using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace SmartHintDev.Api.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        protected ICollection<string> Errors = new List<string>();

        protected ActionResult CustomResponse(object result = null)
        {
            if (ValidarOperacao())
            {
                return Ok(new
                {
                    code = (int)HttpStatusCode.OK,
                    success = true,
                    errors = Errors.ToArray(),
                    model = result
                }); ;
            }

            return BadRequest(new
            {
                code = (int)HttpStatusCode.BadRequest,
                success = false,
                errors = Errors.ToArray()
            });
        }

        protected bool ValidarOperacao()
        {
            return !Errors.Any();
        }

        protected void AdicionarMensagemErro(string error)
        {
            Errors.Add(error);
        }

        protected void AdicionarMensagemErro(List<string> errors)
        {
            foreach (string error in errors)
            {
                Errors.Add(error);
            }
        }

        protected void LimparErros()
        {
            Errors.Clear();
        }

    }
}
