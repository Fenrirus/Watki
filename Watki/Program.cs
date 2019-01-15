using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Watki
{
    class Program
    {
        static readonly Object locker = new Object();
        static bool wartosc = false;
        static void Main(string[] args)
        {
            Thread thread1 = new Thread(() => wypisz(3));
            Thread thread2 = new Thread(() => wypisz3(5));
            Thread thread3 = new Thread(() => wypisz(4));
            thread1.Start();
           // thread1.Join();
            thread2.Start();
            thread3.Start();
            wypisz2(2);

            Task<string> task = Task.Run(() =>
            {
                return "task";
            });
        
            string wyrazenie = task.Result;
            Console.WriteLine(wyrazenie);

            Console.ReadKey();
        }

        static void wypisz(int ile)
        {
            lock (locker) {
                if (wartosc)
                {
                    for (int i = 0; i < ile; i++)
                    {
                        Console.WriteLine("Done");
                    }
                }
                wartosc = true;
            }
        }
        static void wypisz2(int ile)
        {
            for (int i = 0; i < ile; i++)
            {
                Console.WriteLine("A");
            }
        }
        static void wypisz3(int ile)
        {
            for (int i = 0; i < ile; i++)
            {
                Console.WriteLine("D");
            }
        }
    }
  
}
