using System;
using System.IO;
using System.Runtime.InteropServices;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace techchallegertelegramchatbot
{
    class telegrambot
    {
        /// <summary>
        /// Declare Telegrambot object
        /// </summary>
        private static readonly TelegramBotClient bot = new TelegramBotClient("1389684620:AAESfTkWLx0_SDLPVIu-sH6zyDdugNd-lvk");

        /// <summary>
        /// csharp corner chat bot web hook
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            bot.OnMessage += Csharpcornerbotmessage;
            bot.StartReceiving();
            Console.ReadLine();
            bot.StopReceiving();

        }

        /// <summary>
        /// Handle bot webhook
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Csharpcornerbotmessage(object sender, MessageEventArgs e)
        {
            if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
                PrepareQuestionnaires(e);
        }
        public static void PrepareQuestionnaires(MessageEventArgs e)
        {
            var entracase = 0;   
            var conversationReference = e.Message.Text.ToLower();

            switch (conversationReference)
            {
                case "olá":
                case "ola":
                case "oi":
                    {
                        bot.SendTextMessageAsync(e.Message.Chat.Id, "Olá" + Environment.NewLine + "Bem vindo ao Atendimento Carrefour." 
                                                                          + Environment.NewLine + "Posso ajudar ?");
                        entracase = 1;
                        break;
                    }
                case "gostaria de saber sobre os produtos":
                case "me fale sobre os produtos":
                case "produtos":
                    {
                        bot.SendTextMessageAsync(e.Message.Chat.Id, "Sim claro..!!" + Environment.NewLine 
                                                                                    + "Escolha a opção para mais detalhes:" 
                                                                                    + Environment.NewLine + "1 - Cartão" 
                                                                                    + Environment.NewLine + "2 - Seguro"
                                                                                    + Environment.NewLine + "3 - Serviços"
                                                                                    + Environment.NewLine + "4 - Promoções"
                                                                                    + Environment.NewLine + "5 - Nosso Blog");
                        entracase = 1; 
                        break;
                    }
                case "1": 
                    {
                        bot.SendTextMessageAsync(e.Message.Chat.Id, "https://www.carrefoursolucoes.com.br/cartao/beneficios"
                            + Environment.NewLine + "Cartão de Crédito | Carrefour Soluções Financeiras"
                            + Environment.NewLine + "Confira os seguros disponíveis e as vantagens para clientes Cartões Carrefour.");
                        bot.SendTextMessageAsync(e.Message.Chat.Id, "Mais alguma coisa?");
                        entracase = 1; 
                        break;
                    }
                case "2": 
                    {
                        bot.SendTextMessageAsync(e.Message.Chat.Id, "https://www.carrefoursolucoes.com.br/seguros1");
                        bot.SendTextMessageAsync(e.Message.Chat.Id, "Mais alguma coisa?");
                        entracase = 1; 
                        break;
                    }
                case "3": 
                    {
                        bot.SendTextMessageAsync(e.Message.Chat.Id, Environment.NewLine + "https://www.carrefoursolucoes.com.br/servicos");
                        bot.SendTextMessageAsync(e.Message.Chat.Id, "Mais alguma coisa?"); 
                        entracase = 1; 
                        break;
                    }
                case "4":
                    {
                        bot.SendTextMessageAsync(e.Message.Chat.Id, Environment.NewLine + "https://www.carrefoursolucoes.com.br/promocao");
                        bot.SendTextMessageAsync(e.Message.Chat.Id, "Mais alguma coisa?"); 
                        entracase = 1;
                        break;
                    }

                case "5":
                    {
                        bot.SendTextMessageAsync(e.Message.Chat.Id, Environment.NewLine + "https://www.carrefoursolucoes.com.br/blog");
                        bot.SendTextMessageAsync(e.Message.Chat.Id, "Mais alguma coisa?"); 
                        entracase = 1;
                        break;
                    }
                case "tchau":
                case "ok":
                case "obrigado": 
                    {
                        bot.SendTextMessageAsync(e.Message.Chat.Id, "De nada..!!  Até breve !");
                        entracase = 1; 
                        break;
                    }
            };

            if (entracase == 0)
                bot.SendTextMessageAsync(e.Message.Chat.Id, "No momento ainda não tenho esta informação ! "
                                                             + Environment.NewLine + "Procure nossa central de atendimento !"
                                                             + Environment.NewLine + "https://www.carrefoursolucoes.com.br/fale-conosco");
 
        }
    }
}
