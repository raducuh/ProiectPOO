using System;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;

namespace proiect
{
    class Program
    {
        static void Main(string[] args)
        {
            var Logger = new Logare();
            while (true)
            {
                Console.WriteLine("1.Logare ");
                Console.WriteLine("2.  ");
                Console.WriteLine("3.  ");
                Console.WriteLine("4. ");
                Console.WriteLine("Alegeti o optiune: ");
                int optiune= int.Parse(Console.ReadLine());
                switch (optiune)
                {
                    case 1:
                        Logger.AddUtilizator();
                        Logger.AfisareUtilizatori();
                        break;
                    
                }
                
            }
        }
    }
}