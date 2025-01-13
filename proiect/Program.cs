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
                Console.WriteLine("\n\t\t\tBINE AI VENIT!\n");
                Console.WriteLine("\t1. Logare");
                Console.WriteLine("\t2. Autentificare (Adauga un utilizator nou)");
                Console.WriteLine("\t3. Iesire\n");
                int optiune;
                while (!int.TryParse(Console.ReadLine(), out optiune) || (optiune != 1 && optiune != 2 && optiune != 3))
                {
                    Console.WriteLine("OPTIUNE INVALIDA!");
                    Console.WriteLine("\t1. Logare");
                    Console.WriteLine("\t2. Autentificare (Adauga un utilizator nou)");
                    Console.WriteLine("\t3. Iesire");
                }

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
                                    
                                    Console.WriteLine("\t\tMeniu Organizator:");
                                    Console.WriteLine("\t1. Lansare Eveniment");
                                    Console.WriteLine("\t2. Afiseaza evenimente/Salveaza in fisier.");
                                    Console.WriteLine("\t3. Trimite update eveniment.");
                                    Console.WriteLine("\t4. Afisare Reviews eveniment.");
                                    Console.WriteLine("\t5. Iesire.");
                                    int optiune2 = Convert.ToInt32(Console.ReadLine());

                                    switch (optiune2)
                                    {
                                        case 1:
                                            organizator.LansareEveniment();
                                            break;
                                        case 2:
                                            organizator.ObtineEvenimente();
                                            organizator.SalvareEvenimenteInFisier();
                                            break;
                                        case 3:
                                            organizator.DetaliiEvenimentUpdate();
                                            break;
                                        case 4:
                                            organizator.VerificareReviews();
                                            break;
                                        case 5:
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
                                    
                                    Console.WriteLine("\t\tMeniul  clientului:");
                                    Console.WriteLine("\t1. Vizualizare evenimente.");
                                    Console.WriteLine("\t2. Inscriere la eveniment.");
                                    Console.WriteLine("\t3. Istoricul participarii dumneavoastra la evenimentele noastre.");
                                    Console.WriteLine("\t4. Acordarea unui review.");
                                    Console.WriteLine("\t5. Verificare update evenimente.");
                                    Console.WriteLine("\t6. Iesire");
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
                                            client.VizualizareIstoric();
                                            break;
                                        case 4:
                                            client.AcordaReview();
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