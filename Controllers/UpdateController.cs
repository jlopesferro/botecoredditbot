using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Examples.WebHook.Services;
using Telegram.Bot.Types;

namespace Telegram.Bot.Examples.WebHook.Controllers
{
    [Route("api/Telegram")]
    public class UpdateController : Controller
    {
        private readonly IUpdateService _updateService;
        ILogger _logger;
        Update _update;

        public UpdateController(IUpdateService updateService, ILogger<UpdateController> logger)
        {
            _updateService = updateService;
            _logger = logger;
        }

        // POST api/update
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Update update)
        {

            conta();
            return Ok();









            // Ignorando mensagens nulas
            if (update.Message.Text == null)
                return Ok();

            // Preparando objeto Update para uso em outros pontos da classe
            _update = update;

            // Removendo sufixo do próprio bot
            update.Message.Text = update.Message.Text.Replace("@BotecoRedditBot", "");

            _logger.LogInformation("Respondendo mensagem...");

            // Validando tipo de mensagem (completa/commandos apenas)
            switch (update.Message.Text)
            {
                case("/MulherPraSerBoa"):
                case("MulherPraSerBoa"):
                    mulherpraserboa();
                    return Ok();
                    break;
            }

            // Validando mensagem à partir de conteúdo livre
            if (_update.Message.Text.ToLower().Contains("conta"))
            {
                conta();
                return Ok();
            }

            return Ok();
        }


        private void mulherpraserboa()
        {
            Responder("tem");
            Thread.Sleep(100);
            Responder("que");
            Thread.Sleep(100);
            Responder("ter");
            Thread.Sleep(100);
            Responder("🍆 !!!");
        }
        
        private void conta()
        {
            Random rnd = new Random();
            double valor = rnd.Next(9,150);
            Responder("Conta? Tá na mão, chefe! Teu valor é R$ " + valor.ToString() + ",90. Cartão?!?");
        }

        private async void Responder(string novaMensagem)
        {
            _update.Message.Text = novaMensagem;
            await _updateService.EchoAsync(_update);
        }
    }
}
