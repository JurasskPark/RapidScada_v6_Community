using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommunicationMethods
{
    public class MessageDictionary
    {
        private Mutex mut = new Mutex();
        private List<Message> list;

        public MessageDictionary()
        {
            list = new List<Message>();
        }

        public void Add(Message msg)
        {
            mut.WaitOne();
            list.Add(msg);
            try
            {
                if (list.Count > 20)
                {
                    UpdateSql();
                }
            }
            finally
            {
                mut.ReleaseMutex();
            }
        }

        public void UpdateSql()
        {
            list.Clear();
        }
    }
}