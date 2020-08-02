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
                case "/start":
                    {
                        bot.SendTextMessageAsync(e.Message.Chat.Id, "Olá" + Environment.NewLine + "Bem vindo ao Atendimento Banco Carrefour." 
                                                                          + Environment.NewLine + "Posso ajudar ?");
                        entracase = 1;
                        break;
                    }
                case "gostaria de saber sobre os produtos":
                case "sim, gostaria de saber sobre produtos":
                case "sim, gostaria de informação de seu produtos":
                case "gostaria de informações sobre os produtos":
                case "gostaria de informações dos produtos":
                case "gostaria de informações de produtos":
                case "sim, gostaria de informações sobre produtos":
                case "quais produtos vocês tem ?":
                case "quais produtos vocês trabalham ?":
                case "me fale sobre os produtos":
                case "produtos":
                case "produtos e serviços":
                case "sim":
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
                case "gostaria de saber sobre cartão":
                case "gostaria de saber sobre cartão de crédito":
                case "cartão":
                case "cartões":
                case "cartão de crédito":
                    {
                        bot.SendTextMessageAsync(e.Message.Chat.Id, "https://www.carrefoursolucoes.com.br/cartao/beneficios"
                            + Environment.NewLine);
                        bot.SendTextMessageAsync(e.Message.Chat.Id, "Mais alguma coisa?");
                        entracase = 1; 
                        break;
                    }
                case "2":
                case "seguro":
                case "seguro cartão":
                case "seguros cartão":
                case "seguro de cartão":
                case "seguro residencial":
                case "tem seguro residencial ?":
                case "proteção hospitalar":
                case "proteção dental":
                    {
                        bot.SendTextMessageAsync(e.Message.Chat.Id, "https://www.carrefoursolucoes.com.br/seguros1");
                        bot.SendTextMessageAsync(e.Message.Chat.Id, "Mais alguma coisa?");
                        entracase = 1; 
                        break;
                    }
                case "3":
                case "parcelamento":
                case "parcelamento de cartão":
                case "crédito pessoal":
                case "pagamento de contas":
                case "saque de dinheiro":
                    {
                        bot.SendTextMessageAsync(e.Message.Chat.Id, Environment.NewLine + "https://www.carrefoursolucoes.com.br/servicos");
                        bot.SendTextMessageAsync(e.Message.Chat.Id, "Mais alguma coisa?"); 
                        entracase = 1; 
                        break;
                    }
                case "4":
                case "promoções":
                case "tem alguma promoção para que tem cartão carrefour ?":
                case "tem promoções para clientes ?":
                case "tem alguma promoção para clientes ?":
                case "promoção":
                case "alguma promoção ?":
                    {
                        bot.SendTextMessageAsync(e.Message.Chat.Id, Environment.NewLine + "https://www.carrefoursolucoes.com.br/promocao");
                        bot.SendTextMessageAsync(e.Message.Chat.Id, "Mais alguma coisa?"); 
                        entracase = 1;
                        break;
                    }

                case "5":
                    {
                        bot.SendTextMessageAsync(e.Message.Chat.Id, Environment.NewLine + "Visite nosso Blog !!");
                        bot.SendTextMessageAsync(e.Message.Chat.Id, Environment.NewLine + "https://www.carrefoursolucoes.com.br/blog");
                        bot.SendTextMessageAsync(e.Message.Chat.Id, "Mais alguma coisa?"); 
                        entracase = 1;
                        break;
                    }
                case "6":
                case "7":
                case "8":
                case "9":
                    {
                        bot.SendTextMessageAsync(e.Message.Chat.Id, "Opção inválida !!" + Environment.NewLine + " "
                                                                                    + Environment.NewLine + "Escolha a opção para mais detalhes:"
                                                                                    + Environment.NewLine + "1 - Cartão"
                                                                                    + Environment.NewLine + "2 - Seguro"
                                                                                    + Environment.NewLine + "3 - Serviços"
                                                                                    + Environment.NewLine + "4 - Promoções"
                                                                                    + Environment.NewLine + "5 - Nosso Blog");
                        entracase = 1;
                        break;
                    }
                case "tchau":
                case "ok":
                case "obrigado":
                case "não, obrigado":
                case "não obrigado":
                case "ok, obrigado !":
                case "ok, obrigado":
                case "ok obrigado":
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
