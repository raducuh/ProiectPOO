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
            
            var organizator = new Organizator(1, "Ion", "Popescu", "ion.popescu@example.com", "parola123");
            organizator.LansareEveniment();
            Console.WriteLine("Lista evenimentelor lansate:");
            foreach (var eveniment in organizator.Evenimente)
            {
                Console.WriteLine($"- {eveniment.Nume}, {eveniment.Data.ToShortDateString()}");
            }
            var client1 = new Client(5, "gigi", "becali", "email", "123");
            var client2 = new Client(5, "gigi2", "becali2", "email2", "123");

            var review1 = new Review(client1, 0);
       
            var review2 = new Review(client1, 0);
         
            organizator.VerificareReviews();
          
        
            
            
            
            /*
            var logger = new Logare();
            while (true)
            {
                Console.WriteLine("1. Logare ");
                Console.WriteLine("2. Delogare");
                Console.WriteLine("3. Inregistrare");
                Console.WriteLine("4. Iesire");

            while (true)
            {
                Console.WriteLine("1.Logare ");
                Console.WriteLine("2. ceva  ");
                Console.WriteLine("3.  ");
                Console.WriteLine("4. ");

                Console.WriteLine("Alegeti o optiune: ");
                int optiune= int.Parse(Console.ReadLine());
                switch (optiune)
                {


                    case 1:
                        logger.AfisareUtilizatori();
                        break;
                    case 2:
                        break;
                    case 3:
                        logger.AddUtilizator();
                        break;

                    

                }
                
                
            }
            */
        }
    }
}