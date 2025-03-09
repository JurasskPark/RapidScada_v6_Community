using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationMethods
{
    public class Message
    {
        public string data { get; set; }
        public string ip { get; set; }
        public DateTime getDate { get; set; }

        public Message()
        {
            getDate = DateTime.Now;
        }

        public override string ToString()
        {
            return "[" + getDate.ToString() + "][" + ip + "][Получено]" + data + "";
        }
    }
}