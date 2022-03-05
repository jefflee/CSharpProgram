using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CSharpProgram.Test
{
    public class EnumerateConcurrentQueue
    {
        /// <summary>
        /// Try to test enumerate a Queue in two concurrent Tasks.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task Execute_Queue()
        {
            Queue<string> cQueue = new Queue<string>();
            for (int k = 0; k < 10; k++)
            {
                cQueue.Enqueue($"Data number {k}");
            }

            await Test(cQueue);
        }

        /// <summary>
        /// Try to test enumerate a ConcurrentQueue in two concurrent Tasks.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task Execute_ConcurrentQueue()
        {
            ConcurrentQueue<string> cQueue = new ConcurrentQueue<string>();
            for (int k = 0; k < 10; k++)
            {
                cQueue.Enqueue($"Data number {k}");
            }

            await Test(cQueue);
        }

        private async Task Test(IEnumerable<string> queue)
        {
            IList<Task> tasks = new List<Task>();
            tasks.Add(Task.Run(() => Print(queue, "May")));
            tasks.Add(Task.Run(() => Print(queue, "Tuf Gaming")));
            await Task.WhenAll(tasks);
        }

        private void Print(IEnumerable<string> queue, string tag)
        {
            foreach (var s in queue)
            {
                Thread.Sleep(1);
                Console.WriteLine($"{tag} : {s}");
            }
        }
    }
}