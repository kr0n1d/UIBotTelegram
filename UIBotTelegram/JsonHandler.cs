using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;

namespace UIBotTelegram
{
    class JsonHandler
    {
        public static JsonHandler Instance = new JsonHandler();
        private JsonHandler() { }

        public void Save(Telegram.Bot.Args.MessageEventArgs e)
        {
            if (!File.Exists("Log.txt"))
            {
                using (var fs = File.Create("Log.txt"))
                {
                    using (var sw = new StreamWriter(fs))
                    {
                        var text = "{ \"ok\": true, \"users\": [ { \"first_name\": Test \"chat_id\": 12345678912, \"messages\": [ { \"00:00:00\": \"Test\" } ] } ]}";
                        sw.WriteLine(text);
                    }
                }
            }

            JObject main = JObject.Parse(File.ReadAllText("Log.txt"));
            JArray users = JArray.Parse(main["users"].ToString());

            bool has = false;

            foreach (var user in users)
            {
                if (user["first_name"].ToString() == e.Message.From.FirstName)
                {
                    has = true;
                }
            }

            if (!has)
            {
                JObject tempUser = new JObject();
                tempUser["first_name"] = e.Message.From.FirstName;
                tempUser["chat_id"] = e.Message.Chat.Id;
                JArray messages = new JArray();
                tempUser["messages"] = messages;
                users.Add(tempUser);
            }

            foreach (var user in users)
            {
                if (e.Message.From.FirstName == user["first_name"].ToString())
                {
                    JArray messages = JArray.Parse(user["messages"].ToString());

                    JObject msg = new JObject();
                    msg[e.Message.Date.ToLongTimeString()] = e.Message.Text;

                    messages.Add(msg);
                    user["messages"] = messages;
                }
            }
            main["users"] = users;

            File.WriteAllText("Log.txt", main.ToString());
        }

        public ObservableCollection<MessageLog> Load()
        {
            ObservableCollection<MessageLog> listLogs = new ObservableCollection<MessageLog>();

            if (!File.Exists("Log.txt"))
                return listLogs;

            JObject main = JObject.Parse(File.ReadAllText("Log.txt"));
            JArray users = JArray.Parse(main["users"].ToString());
            int count = 0;
            foreach (var user in users)
            {
                JArray messages = JArray.Parse(user["messages"].ToString());
                foreach (var msg in messages)
                {
                    var temp = msg.ToString().Replace('{', ' ').Replace('}', ' ').Trim().Split(':');
                    var time1 = temp[0].Replace('\"', ' ').Trim();
                    var time2 = temp[1].Replace('\"', ' ').Trim();
                    var time3 = temp[2].Replace('\"', ' ').Trim();
                    var time = String.Join(':', time1, time2, time3);
                    var text = temp[3].Replace('\"', ' ').Trim();
                    long id = Convert.ToInt64(user["chat_id"].ToString());
                    string firstName = user["first_name"].ToString();
                    listLogs.Add(new MessageLog(time, text, firstName, id));
                }
                ++count;
            }

            MessageBox.Show($"Загрузка прошла успешно!\nВсего пользователей: {count}", "Загрузка", MessageBoxButton.OK, MessageBoxImage.Information);

            return listLogs;
        }
    }
}
