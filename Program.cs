using Telegram.BotAPI;
using Telegram.BotAPI.AvailableMethods;
using Telegram.BotAPI.GettingUpdates;


internal class Programm
{
    private static void Main(string[] args)
    {
        string token = "";
        BotClient api = new BotClient(token);
        var updates = api.GetUpdates();
        while (true)
        {
            if (updates.Any())
            {
                foreach (var update in updates)
                {
                    api.SendMessage(update.Message.Chat.Id,GetText(update.Message.Text.ToLower()));
                }
                var offset = updates.Last().UpdateId + 1;
                updates = api.GetUpdates(offset);

            } 
           else
            {
                updates = api.GetUpdates();
            }
              
        }

    } 
    private static string GetText(string questions)
    {
        if (questions == "привет")
            return "здарова";

        if (questions == "какая погода?") 
            return "пасмурно, возможен дождь,возьмите зонтик ";
        
        if(questions == "что съесть мне на ужин?")
            return "зайдите в куевси";

        if (questions == "можно я сегодня не пойду на пары?")
            return "нет,ты должен";

        if (questions == "кому?")
            return "родине";

        return "а, ой";
         
       



    }
}



