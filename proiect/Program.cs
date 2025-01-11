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
           
            while (true)
            {
                Console.WriteLine("Alege o optiune: ");
                int optiune = Convert.ToInt32(Console.ReadLine());
                switch (optiune)
                {
                    case 1:
                        organizator.LansareEveniment();
                        break;
                    case 2:
                        
                        break;
                    case 3:
                        organizator.AfisareEvenimente();
                        break;
                    case 4:
                        organizator.VerificareReviews();
                        break;
                    
                }
            }

         
            organizator.VerificareReviews();
            organizator.AfisareEvenimente();
          
        
            
            
            
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