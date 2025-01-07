namespace PedidoApi.Services
{
    public class ClienteService
    {
        private readonly HttpClient _httpClient;

        public ClienteService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Cliente?> ObterClientePorId(int id)
        {
            var response = await _httpClient.GetAsync($"api/Cliente/{id}");
            if (!response.IsSuccessStatusCode)
                return null; // Retorna null se o cliente não existir

            return await response.Content.ReadFromJsonAsync<Cliente>();
        }

        public class Cliente
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Email { get; set; }
        }
    }
}