﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommunicationMethods
{
    public class TaskQueue<T> : IDisposable where T : class
    {
        protected object locker = new object();
        Thread[] workers;
        protected Queue<T> taskQ = new Queue<T>();

        public TaskQueue(int workerCount)
        {
            workers = new Thread[workerCount];

            // Create and start a separate thread for each worker
            for (int i = 0; i < workerCount; i++)
                (workers[i] = new Thread(Consume)).Start();
        }

        public void Dispose()
        {
            // Enqueue one null task per worker to make each exit.
            foreach (Thread worker in workers) EnqueueTask(null);
            foreach (Thread worker in workers) worker.Join();
        }

        public virtual void EnqueueTask(T task)
        {
            lock (locker)
            {
                if (taskQ.Count < 100)
                {
                    taskQ.Enqueue(task);
                }
                Monitor.PulseAll(locker);
            }
        }

        protected virtual void Consume()
        {
            while (true)
            {
                T task;
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
                Console.WriteLine();
            }
        }
    }
}