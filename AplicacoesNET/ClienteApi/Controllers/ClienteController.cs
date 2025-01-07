using Microsoft.AspNetCore.Mvc;

namespace ClienteApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        [HttpPost]
        public IActionResult CriarCliente([FromBody] Cliente cliente)
        {
            return Ok(new { mensagem = "Cliente criado com sucesso!", cliente });
        }

        [HttpGet("{id}")]
        public IActionResult ObterCliente(int id)
        {
            var cliente = new Cliente { Id = id, Nome = "João Silva", Email = "joao@email.com" };
            return Ok(cliente);
        }

        public class Cliente
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Email { get; set; }
        }
    }
}
