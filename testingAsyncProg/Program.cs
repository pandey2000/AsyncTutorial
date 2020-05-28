using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace testingAsyncProg
{
    class Program
    {
        public static Queue<int> q = new Queue<int>();
        
        public static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(0, 10000);
        private static int flag = 0;

        static void Main(string[] args)
        {

            //Console.WriteLine(DateTime.Now.ToString("HH:mm:ss.ffffff"));
            Stopwatch s = new Stopwatch();
            
            //long microseconds = s.ElapsedTicks / (Stopwatch.Frequency / (1000L * 1000L));
            s.Start();
            Task[] tasks = new Task[10000];
            for(int i=0; i<10000; i++)
            {
                tasks[i] = DoSomethingAsync();                
            }
            Console.WriteLine("All tasks created in " +s.ElapsedMilliseconds+" msec");
            semaphoreSlim.Release(10000);
            //sem.Release(10000);
            
            Task.WaitAll(tasks);
            Console.WriteLine("Tasks completed in "+s.ElapsedMilliseconds + " msec");
            Console.ReadKey();
        }


        static async Task DoSomethingAsync() //A Task return type will eventually yield a void
        {
            //await semaphoreSlim.WaitAsync();

            await Task.Delay(1000);

            
            //semaphoreSlim.Release();
        }
    }
}
