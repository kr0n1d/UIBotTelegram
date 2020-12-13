using System;
using System.Collections.Generic;
using System.Text;

namespace UIBotTelegram
{
    struct MessageLog
    {
        public string Time { get; set; }
        public long Id { get; set; }
        public string Msg { get; set; }
        public string FirstName { get; set; }

        public MessageLog(string Time, string Msg, string FirstName, long Id)
        {
            this.FirstName = FirstName;
            this.Msg = Msg;
            this.Time = Time;
            this.Id = Id;
        }
    }
}
