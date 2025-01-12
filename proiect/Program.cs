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
            Logare logare = new Logare();

            while (true)
            {
                Console.WriteLine("1. Logare");
                Console.WriteLine("2. Autentificare (Adauga un utilizator nou)");
                Console.WriteLine("3. Iesire");
                int optiune = Convert.ToInt32(Console.ReadLine());

                switch (optiune)
                {
                    case 1:
                        if (logare.AutentificareUtilizator())
                        {
                            var utilizatorCurent = logare.GetUtilizatorCurent();
                            if (utilizatorCurent is Organizator organizator)
                            {
                                organizator.Meniu(); 
                            }
                            else if (utilizatorCurent is Client client)
                            {
                                client.Meniu(); 
                            }
                        }
                        break;

                    case 2:
                        logare.Autentificare(); 
                        break;

                    case 3:
                        return;
                }
            }
        }
    }
}