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
                                bool iesireMeniu = false;
                                while (!iesireMeniu)
                                {
                                    
                                    Console.WriteLine("Meniu Organizator:");
                                    Console.WriteLine("1. Lansare Eveniment");
                                    Console.WriteLine("2. Afisare Evenimente");
                                    Console.WriteLine("3. Verificare Review-uri");
                                    Console.WriteLine("4. Iesire");
                                    int optiune2 = Convert.ToInt32(Console.ReadLine());

                                    switch (optiune2)
                                    {
                                        case 1:
                                            organizator.LansareEveniment();
                                            break;
                                        case 2:
                                            organizator.ObtineEvenimente();
                                            break;
                                        case 3:
                                            organizator.VerificareReviews();
                                            break;
                                        case 4:
                                            iesireMeniu = true; 
                                            break;
                                    }
                                }
                            }
                            else if (utilizatorCurent is Client client)
                            {
                                bool iesireMeniu = false;
                                while (!iesireMeniu)
                                {
                                    
                                    Console.WriteLine("Meniul  clientului:");
                                    Console.WriteLine("1. Vizualizare evenimente.");
                                    Console.WriteLine("2. Inscriere la eveniment.");
                                    Console.WriteLine("3. Istoricul participarii dumneavoastra la evenimentele noastre.");
                                    Console.WriteLine("4. Acordarea unui review.");
                                    Console.WriteLine("5. Verificare update evenimente.");
                                    Console.WriteLine("6. Iesire");
                                    int optiune2 = Convert.ToInt32(Console.ReadLine());

                                    switch (optiune2)
                                    {
                                        case 1:
                                            client.ObtineEvenimenteDisponibile(logare.ListaUtilizatori.OfType<Organizator>().SelectMany(o => o.Evenimente).ToList());
                                            break;
                                        case 2:
                                            client.InscriereLaEveniment(logare.ListaUtilizatori.OfType<Organizator>().SelectMany(o => o.Evenimente).ToList());
                                            break;
                                        case 3:
                                            break;
                                        case 4:
                                            break;
                                        case 5:
                                            break;
                                        case 6:
                                            iesireMeniu = true;
                                            break;
                                    }
                                }
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