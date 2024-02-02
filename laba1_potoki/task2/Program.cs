using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace ModifiedTask
{
    public class Storage
    {
        public int X = 0;
        public int Y = 0;
        public int Z = 0;
    }

    public class Runner
    {
        public static void Main(string[] args)
        {
            int multiCounter = 0;
            int simpleCounter = 0;

            int quantity = 10000000;
            Random random = new Random();
            var stopwatch = new Stopwatch();

            List<Storage> list1 = new List<Storage>();
            for (int i = 0; i < quantity; i++)
            {
                Storage storage = new Storage();

                storage.X = random.Next(20, 200);
                storage.Y = random.Next(20, 200);
                storage.Z = random.Next(20, 200);

                list1.Add(storage);
            }

            List<Storage> list2 = new List<Storage>();
            for (int i = 0; i < quantity; i++)
            {
                Storage storage = new Storage();

                storage.X = random.Next(20, 200);
                storage.Y = random.Next(20, 200);
                storage.Z = random.Next(20, 200);

                list2.Add(storage);
            }

            List<Storage> list3 = new List<Storage>();
            for (int i = 0; i < quantity; i++)
            {
                Storage storage = new Storage();

                storage.X = random.Next(20, 200);
                storage.Y = random.Next(20, 200);
                storage.Z = random.Next(20, 200);

                list3.Add(storage);
            }

            List<Storage> list4 = new List<Storage>();
            for (int i = 0; i < quantity; i++)
            {
                Storage storage = new Storage();

                storage.X = random.Next(20, 200);
                storage.Y = random.Next(20, 200);
                storage.Z = random.Next(20, 200);

                list4.Add(storage);
            }

            Console.WriteLine("===== Thread Testing =====");
            stopwatch.Reset();
            List<Thread> threadList = new List<Thread>();
            threadList.Add(new Thread(() =>
            {
                foreach (Storage storage in list1)
                {
                    if (storage.Y > 150 && storage.Z > 150 && storage.X > 150)
                    {
                        Interlocked.Increment(ref multiCounter);
                    }
                }

            }));

            threadList.Add(new Thread(() =>
            {
                foreach (Storage storage in list2)
                {
                    if (storage.Y > 150 && storage.Z > 150 && storage.X > 150)
                    {
                        Interlocked.Increment(ref multiCounter);
                    }
                }

            }));

            threadList.Add(new Thread(() =>
            {
                foreach (Storage storage in list3)
                {
                    if (storage.Y > 150 && storage.Z > 150 && storage.X > 150)
                    {
                        Interlocked.Increment(ref multiCounter);
                    }
                }

            }));
            threadList.Add(new Thread(() =>
            {
                foreach (Storage storage in list4)
                {
                    if (storage.Y > 150 && storage.Z > 150 && storage.X > 150)
                    {
                        Interlocked.Increment(ref multiCounter);
                    }
                }

            }));

            stopwatch.Start();
            foreach (Thread thread in threadList)
            {
                thread.Start();
            }

            foreach (Thread thread in threadList)
            {
                thread.Join();
            }
            stopwatch.Stop();
            Console.WriteLine("Large Boxes Count: " + multiCounter);

            Console.WriteLine($"Multithreaded Time: {stopwatch.ElapsedMilliseconds}ms");


            Console.WriteLine();
            Console.WriteLine("===== Sequential Testing =====");

            stopwatch.Reset();
            stopwatch.Start();

            foreach (Storage storage in list1)
            {
                if (storage.Y > 150 && storage.Z > 150 && storage.X > 150)
                {
                    simpleCounter++;
                }
            }
            foreach (Storage storage in list2)
            {
                if (storage.Y > 150 && storage.Z > 150 && storage.X > 150)
                {
                    simpleCounter++;
                }
            }
            foreach (Storage storage in list3)
            {
                if (storage.Y > 150 && storage.Z > 150 && storage.X > 150)
                {
                    simpleCounter++;
                }
            }
            foreach (Storage storage in list4)
            {
                if (storage.Y > 150 && storage.Z > 150 && storage.X > 150)
                {
                    simpleCounter++;
                }
            }
            stopwatch.Stop();
            Console.WriteLine("Large Boxes Count: " + simpleCounter);
            Console.WriteLine($"Sequential Time: {stopwatch.ElapsedMilliseconds}ms");

            Console.ReadLine();
        }

    }
}
