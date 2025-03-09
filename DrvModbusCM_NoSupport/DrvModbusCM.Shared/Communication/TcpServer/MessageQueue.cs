using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommunicationMethods
{
    public class MessageQueue : TaskQueue<Message>
    {
        MessageDictionary msgDic = new MessageDictionary();

        public MessageQueue(int workerCount) : base(workerCount)
        {

        }

        protected override void Consume()
        {
            while (true)
            {
                Message task;
                lock (locker)
                {
                    while (taskQ.Count == 0) Monitor.Wait(locker);
                    task = taskQ.Dequeue();
                }
                if (task == null)
                {
                    return;         //This signals our exit
                }

                Console.WriteLine(task);
                msgDic.Add(task);
                Console.WriteLine();
            }
        }
    }
}