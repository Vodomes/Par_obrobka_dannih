using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task1Thread
{
    public class Program
    {
        static void ExecuteThread()
        {
            Thread currentThread = Thread.CurrentThread;
            Console.WriteLine($"ID: {currentThread.ManagedThreadId}  || Priority: {currentThread.Priority}  || State: {currentThread.ThreadState}");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Create 10 threads:");
            for (int counter = 0; counter < 10; counter++)
            {
                Thread newThread = new Thread(ExecuteThread);
                newThread.Name = $"Thread #{counter + 1}";
                newThread.Priority = ThreadPriority.AboveNormal;
                newThread.Start();
            }
        }
    }
}
