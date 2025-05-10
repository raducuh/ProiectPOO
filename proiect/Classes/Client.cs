namespace DefaultNamespace;

public class Client:Utilizator
{
        public List<Event> EvenimenteDisponibile { get; private set; }
        public List<Event> IstoricEvenimente { get;private set; }
        public Client(int id, string nume, string prenume, string email, string parola) : base(id, nume, prenume, email,
                parola)
        {
                EvenimenteDisponibile = new List<Event>();
                IstoricEvenimente= new List<Event>();
        }


        public void ObtineEvenimenteDisponibile(List<Event> evenimente) // Aici primesti lista de evenimente
        {
                Console.WriteLine("Evenimente disponibile pentru client:");
                foreach (var eveniment in evenimente)
                {
                        Console.WriteLine($"ID: {eveniment.EventId}, Nume: {eveniment.Nume}, Data: {eveniment.Data}");
                }
        }

        public void InscriereLaEveniment(List<Event> evenimente)
        {
                ObtineEvenimenteDisponibile(evenimente);
                Console.WriteLine("Introduceti numarul evenimentului la care doriti sa va inscrieti:");
                if (!int.TryParse(Console.ReadLine(), out int evenimentIndex) || evenimentIndex < 1 || evenimentIndex > evenimente.Count)
                {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Numar eveniment invalid.");
                        Console.ResetColor();
                        return;
                }
                
                // caut evenimentul selectat
                var eveniment = evenimente[evenimentIndex - 1];

                if (eveniment == null)
                {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Evenimentul cu acest ID nu exista.");
                        Console.ResetColor();
                        return;
                }
                if (eveniment.Participanti.Contains(this)) // aici verific sa nu se inscrie de 2 ori la aceelasi eveniment
                {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Ati fost deja inscris la evenimentul '{eveniment.Nume}'!");
                        Console.ResetColor();
                        return;
                }
                // verific daca mai sunt locuri disponibile
                if (eveniment.Capacitate - eveniment.Participanti.Count <= 0)
                {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Nu mai sunt locuri disponibile pentru acest eveniment.");
                        Console.ResetColor();
                        return;
                }
                // adaug clientul in lista
                eveniment.Participanti.Add(this);
                IstoricEvenimente.Add(eveniment);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"V-ati inscris cu succes la evenimentul '{eveniment.Nume}'!Va multumim!");
                Console.ResetColor();

                // actualizez capacitatea 
                Console.WriteLine($"Locuri ramase: {eveniment.Capacitate - eveniment.Participanti.Count}");

        }

        public void VizualizareIstoric()
        {
                Console.WriteLine("Istoricul participarii dumneavoastra la evenimentele organizate:");
                if (IstoricEvenimente.Count == 0)
                {
                        Console.WriteLine("Nu ati participat pana acum la niciun eveniment.");
                        
                }
                else
                {
                        foreach (var eveniment in IstoricEvenimente)
                        
                        {
                                Console.WriteLine($"Evenimentul {eveniment.Nume} din data {eveniment.Data}");    
                        }
                }
        }

    public void AcordaReview()
    {
            if (IstoricEvenimente.Count == 0)
            {
                    Console.WriteLine("Nu aveti niciun eveniment la care sa acordati un review.");
                    return;
            }
            Console.WriteLine("Selectati evenimentul la care doriti sa acordati un review:");
            for (int i = 0; i < IstoricEvenimente.Count; i++)
            {
                    var eveniment = IstoricEvenimente[i];
                    Console.WriteLine($"{i + 1}. Evenimentul '{eveniment.Nume}' din data {eveniment.Data}");
            }

            Console.WriteLine("Introduceti numarul evenimentului la care doriti sa acordati review-ul:");
            if (!int.TryParse(Console.ReadLine(), out int evenimentIndex) || evenimentIndex < 1 || evenimentIndex > IstoricEvenimente.Count)
            {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Numar eveniment invalid.");
                    Console.ResetColor();
                    return;
            }

            var evenimentSelectat = IstoricEvenimente[evenimentIndex - 1];
            
            Review review = new Review(this, 0);  
            review.AcordareFeedback(evenimentSelectat);

            evenimentSelectat.AdaugaReview(review);
    
            review.SalveazaReview();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Review-ul pentru evenimentul '{evenimentSelectat.Nume}' a fost adaugat cu succes!");
            Console.ResetColor();//nimic
    }

    public void VizualizareUpdate()
    {
            Console.WriteLine("Update-urile pentru evenimentele la care participati:");
            if (IstoricEvenimente.Count == 0)
            {
                    Console.WriteLine("Nu aveti evenimente in istoric pentru a vizualiza update-uri");
                    return;
            }

            string directoryPath = Directory.GetCurrentDirectory();
            string numefisier = "FisiereText";
            string folderPath = Path.Combine(directoryPath, numefisier);
            if (!Directory.Exists(folderPath))
            {
                    Console.WriteLine("Nu exista niciun update salvat momentan.");
                    return;
            }
            foreach (var eveniment in IstoricEvenimente)
            {
                    string fileName = $"Update_Eveniment_{eveniment.EventId}.txt";
                    string filePath = Path.Combine(folderPath, fileName);

                    if (File.Exists(filePath))
                    {
                            Console.WriteLine($"\nUpdate-uri pentru evenimentul '{eveniment.Nume}':");
                            string[] lines = File.ReadAllLines(filePath);
                            foreach (var line in lines)
                            {
                                    Console.WriteLine(line);
                            }
                    }
                    else
                    {
                            Console.WriteLine($"\nNu exista update-uri pentru evenimentul '{eveniment.Nume}'.");
                    }
            }
    }
}

        

 
        
        
        

        
