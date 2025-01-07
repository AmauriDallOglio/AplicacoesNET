using Microsoft.AspNetCore.Mvc;
using PedidoApi.Services;

namespace PedidoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {

        private readonly ClienteService _clienteService;

        public PedidoController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost("CriarPedidoCliente")]
        public async Task<IActionResult> CriarPedidoCliente([FromBody] Pedido pedido)
        {
            var cliente = await _clienteService.ObterClientePorId(pedido.ClienteId);

            if (cliente == null)
                return NotFound($"Cliente com ID {pedido.ClienteId} não encontrado.");

            return Ok(new
            {
                mensagem = "Pedido criado com sucesso!",
                pedido,
                cliente
            });
        }

        [HttpGet("ObterPedido/{id}")]
        public IActionResult ObterPedido(int id)
        {
            var pedido = new Pedido { Id = id, ClienteId = 1, ProdutoId = 2, Quantidade = 1 };
            return Ok(pedido);
        }

        public class Pedido
        {
            public int Id { get; set; }
            public int ClienteId { get; set; }
            public int ProdutoId { get; set; }
            public int Quantidade { get; set; }
        }
    }
}
