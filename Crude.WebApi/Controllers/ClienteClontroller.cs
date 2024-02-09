using Crud.Domain;
using Crud.Repository; 
using Crude.Aplication.ViewModel;
using Microsoft.AspNetCore.Mvc;


namespace Crud.Controllers
{
    [ApiController]
    [Route("v1")]
    public class ClienteController : ControllerBase
    {
        private readonly ICliente _clienteService; 

        public ClienteController(ICliente clienteService) 
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        [Route("cliente")]
        public IActionResult Get()
        {
            var clientes = _clienteService.GetAll();
            return Ok(clientes);
        }

        [HttpGet]
        [Route("cliente/{id}")]
        public IActionResult GetById(int id)
        {
            var cliente = _clienteService.Get(id); 
            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }

        [HttpPost]
        [Route("cliente")]
        public async Task<IActionResult> PostAsync([FromBody] CriarCliente model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var cliente = new Cliente
            (
                model.Nome,
                model.Email,
                model.Telefone,
                model.Cpf
            );

            try
            {
                _clienteService.Add(cliente);
                await _clienteService.SaveChangesAsync();
                return Created($"v1/cliente/{cliente.Id}", cliente);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("cliente/{id}")]
        public async Task<IActionResult> PutAsync([FromBody] CriarCliente model, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var cliente = _clienteService.Get(id); 
            if (cliente == null)
                return NotFound();

            try
            {
                cliente.Nome = model.Nome;
                cliente.Email = model.Email;
                cliente.Cpf = model.Cpf;
                cliente.Telefone = model.Telefone;

                _clienteService.Update(cliente); 
                await _clienteService.SaveChangesAsync(); 
                return Ok(cliente);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("cliente/{id}")] 
        public async Task<IActionResult> DeleteAsync([FromRoute] int id) 
        {
            var cliente = _clienteService.Get(id); 
            if (cliente == null)
                return NotFound();

            try
            {
                _clienteService.Remove(cliente);
                await _clienteService.SaveChangesAsync(); 
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
