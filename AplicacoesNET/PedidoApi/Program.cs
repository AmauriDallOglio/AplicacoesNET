using PedidoApi.Services;

namespace PedidoApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configuração de serviços
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Adicionar HttpClient para ClienteService
            builder.Services.AddHttpClient<ClienteService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7081");
            });

            var app = builder.Build();

            // Configuração do Swagger
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pedido API V1");
                });
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();


            // Confirmação de inicialização
            Console.WriteLine("---> API inicializada. Acesse: https://localhost:7158/swagger");


            app.Run();
        }
    }
}



//Solution
//│
//├── ClienteApi
//│   └── Controllers
//│       └── ClienteController.cs
//│   └── Program.cs
//│   └── launchSettings.json
//│
//├── PedidoApi
//│   └── Controllers
//│       └── PedidoController.cs
//│   └── Program.cs
//│   └── launchSettings.json


//Defina projetos múltiplos para inicializar: Clique com o botão direito na solução(Solution) e vá em Properties, na aba Startup Project, selecione a opção Multiple startup projects, configure ambos os projetos(ClienteApi e PedidoApi) com a ação Start.

