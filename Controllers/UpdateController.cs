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
        public async Task<IActionResult> Post([FromBody] Update update)
        {
            // Ignorando mensagens nulas
            if (update.Message == null)
                return Ok();
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
                case ("/MulherPraSerBoa"):
                case ("MulherPraSerBoa"):
                    mulherpraserboa();
                    return Ok();
                    break;
            }

            // Validando mensagem à partir de conteúdo livre (palavra-chave)
            if (_update.Message.Text.ToLower().Contains("conta"))
            {
                conta();
                return Ok();
            }
            if (_update.Message.Text.ToLower().Contains("rojão"))
            {
                RojaoTop();
                return Ok();
            }
            if (_update.Message.Text.ToLower().Contains("desce outra"))
            {
                Responder("Taokei, corno!");
                return Ok();
            }


            // Validando mensagem completa
            if (_update.Message.Text.ToLower() == "teste")
            {
                //Responder("\uD83C\uDFFD");
                RojaoTop();
                //Responder("\ud83c\udf86");
                return Ok();
            }
            if (_update.Message.Text.ToLower() == "garçom" ||
                _update.Message.Text.ToLower() == "ei, garçom" ||
                _update.Message.Text.ToLower() == "ei garçom" || 
                _update.Message.Text.ToLower() == "campeão" ||
                _update.Message.Text.ToLower() == "ei campeão" ||
                _update.Message.Text.ToLower() == "ei, campeão" ||
                _update.Message.Text.ToLower() == "capitão" ||
                _update.Message.Text.ToLower() == "ei capitão" ||
                _update.Message.Text.ToLower() == "ei, capitão" ||
                _update.Message.Text.ToLower() == "capitao" ||
                _update.Message.Text.ToLower() == "ei capitao" ||
                _update.Message.Text.ToLower() == "ei, capitao" ||
                _update.Message.Text.ToLower() == "bigode" ||
                _update.Message.Text.ToLower() == "ei bigode" ||
                _update.Message.Text.ToLower() == "ei, bigode")
            {
                eigarcom();
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

        private async void RojaoTop()
        {

            Responder("Ôpa, demorou! Vou preparar, aguenta ae");
            Thread.Sleep(8000);
            rojao();
        }

        private void conta()
        {
            Random rnd = new Random();
            double valor = rnd.Next(9, 150);
            Responder("Conta? Tá na mão, chefe! Teu valor é R$ " + valor.ToString() + ",90. Cartão?!?");
        }

        private void eigarcom()
        {
            Random rnd = new Random();
            double valor = rnd.Next(1, 5);
            switch(valor)
            {
                case 1:
                    Responder("E aí, chefe! Posso mandar descer a Heineken de sempre?!");
                    break;
                case 2:
                    Responder("Opa! Vai querer o quê hoje?");
                    break;
                case 3:
                    Responder("Pois sim");
                    break;
                case 4:
                    Responder("Outra Brahma?!?");
                    break;

            }
            
        }

        private async void rojao()
        {
            string mensagem1 = @"ESTOURO

ESTOUROS ESTOURO ESTOURO

BARULHO

CHEIRO DE PÓLVORA
BARULHO ALTO DEMAIS ESTOURO

FOGOS

PÓLVORA

BARULHO

PAPAPAPA

ESTOOOOOOOOUUUUUROOOSSSS";

            string mensagem2 = @"TRATRATRATRATRA
TRATRATRATRATRA
TRATRATRATRATRA
TRATRATRATRATRA
TRATRATRATRATRA
TRATRATRATRATRA
TRATRATRATRATRA

UUUUUUUUUUUUUU
PAAAAAAA
         AAAAAAAAAA
      AAAA
 AAAAAAAAAAAAAA
                      A
                  A
      AAA
 AAAAAAAAA
A
 A
A
 A
A 
A
AAAAAAAAAAAAAA
AAAAAAAAAAAAAA

POOOOOOOOOWW
        OWWWWWWW
  OOOWWWWWWW
  OOOOWWW
OWW
W
PAPAPAPAPAPAPAA

POOOOWWW POOW
POOOOOOOOOOOW";

            string mensagem3 = @"PAPAPATRATRATATA

PAPAPOOOOOOWWW

POOOOOOOOOOWWW

POOOOOOOOOOOOOO

OOOOOOWWWWWWW";

            string mensagem4 = @"Calma doguinhos, gatinhos 
aqui vocês não sofrem ❤

PAPAPAPAPAPAPAPAPAPA PUPUPUPUPUPUPUPUPUPU

AU AU AU! 

-Olha os cachorros ô
seu filho da puta!!! 

TRATRAPOOOOOWWWWW

(não solte fogos, use bots!)";

            string mensagem5 = @"Esse é dos bons pq vai bem longe.

Fiiiiiiiiiiiiiu..

.      　。　　　　•　    　ﾟ　　。
　　.　　　.　　　  　　.　　　　　。　　   。　.
　.　　      。　        ඞ   。　    .    •
•          .🚀
                    。　.
　 　　。　　 　　　　ﾟ　　　.　      　　　.
,　　　　.";

            string mensagem6 = @"-Não, tem um cachorrinho em casa! 

-Se dane os cachorros! 

Parapapapapapapapapapa
Parapapapapapapapapapa
Papara,papara Clack Bum
Parapapapapapapapapapa

Morro do Dendê é ruim de invadir
Nóis com os alemão vamos se divertir
Pq no Dendê eu vou dizer como é que é, 
aqui não tem mole, nem pra D.R.E

Pra subir aqui no morro até a BOPE treme, 
não tem mole pro exército civil nem pra PM, 
eu dou o maior conceito para os amigos meus, 
mas morro do Dendê, também é terra de Deus

Fé em Deus! DJ!

Parapapapapapapapapapa
Parapapapapapapapapapa
Papara, papara
Clack Bum
Parapapapapapapapapapa";

            string mensagem7 = @":sparkler::tada::fireworks::confetti_ball::sparkler::tada::fireworks::confetti_ball::sparkler::tada:
:fireworks::confetti_ball::sparkler::tada::fireworks::confetti_ball::sparkler::tada::fireworks::confetti_ball:
:sparkler::fireworks::confetti_ball::sparkler::tada::fireworks::sparkler::fireworks::confetti_ball::sparkler:
:tada::fireworks::tada::sparkler::confetti_ball::fireworks::tada::sparkler::confetti_ball::tada:
:sparkler::confetti_ball::fireworks::sparkler::tada::sparkler::confetti_ball::fireworks::tada::confetti_ball:
:sparkler::tada::fireworks::fireworks::fireworks::sparkler::sparkler::sparkler::tada::tada:
:fireworks::confetti_ball::sparkler::tada::fireworks::confetti_ball::sparkler::tada::fireworks::confetti_ball:
:sparkler::fireworks::tada::tada::fireworks::confetti_ball::sparkler::tada::fireworks::sparkler:
:tada::fireworks::confetti_ball::sparkler::tada::fireworks::confetti_ball::tada::sparkler::confetti_ball:
:fireworks::tada::sparkler::fireworks::fireworks::sparkler::tada::sparkler::confetti_ball::fireworks:
:tada::sparkler::fireworks::tada::sparkler::fireworks::tada::sparkler::confetti_ball::fireworks:
:sparkler::fireworks::tada::sparkler::confetti_ball::fireworks::tada::sparkler::tada::fireworks:
:tada::sparkler::tada::confetti_ball::fireworks::tada::sparkler::fireworks::sparkler::tada:";

            string mensagem8 = @"barulho de fogos

EITA! 

BARUUUUUULHO DE FOGOS

BARULHO BARULHO BARUUULHOOOOOOOOO

DE

FOGOS

barulho de
FOGOS

Isso mesmo que vc leu

barulho de FOGOOOOOOOOSSSSS

FOGOOS

Gostou bobão? 

Use a sua imaginação
Não me encha mais a paciência!

EEEEEEE

FOGOS!";

            string mensagem9 = @"FFFFFFFFFFFFFFFFFFFFFFF
iiiiiiiiiiiiiiiiiiiiii
iiiiiiiiiiiiiiiiiiiii
iiiiiiiiiiiiiiiiiiii
iiiiiiiiiiiiiiiiiii
iiiiiiiiiiiiiiiiii
iiiiiiiiiiiiiiiii
iiiiiiiiiiiiiiii
iiiiiiiiiiiiiii
iiiiiiiiiiiiii
iiiiiiiiiiiii
iiiiiiiiiiii
iiiiiiiiiii
iiiiiiiiii
iiiiiiiii
iiiiiiii
iiiiiii
iiiiii
iiiii
iiii
iii
ii
i

.............

sssssssssssss

POOOOOOOOO
OOOOOOOOOO
OOOOOOWWW

Aí menó, dá um brek aí
Se liga, desce lá e manda
avisar que o bagulho chegou!

Hoje é festa na favela porra!";

            string mensagem10 = @"Toma teus fogos filho da puta! 

🎉
🎇
🎊
🎉
🎆
🎉
🎆
🎉
🎇
🎊
🎉
🎆
🎉
🎆
🎇
🎊
🎉
🎆
🎉
🎆
🎇
🎊
🎉
🎆
🎉
🎆

Agora enfia tudo no seu cu!";


            Random rnd = new Random();
            double valor = rnd.Next(1, 11);

            if (valor == 1)
                Responder(mensagem1);
            if (valor == 2)
                Responder(mensagem2);
            if (valor == 3)
                Responder(mensagem3);
            if (valor == 4)
                Responder(mensagem4);
            if (valor == 5)
                Responder(mensagem5);
            if (valor == 6)
                Responder(mensagem6);
            if (valor == 7)
                Responder(mensagem6);
            if (valor == 8)
                Responder(mensagem8);
            if (valor == 9)
                Responder(mensagem9);
            if (valor == 10) 
                Responder(mensagem10);
            
        }
        private async void Responder(string novaMensagem)
        {
            _update.Message.Text = novaMensagem;
            await _updateService.EchoAsync(_update);
        }
    }
}
