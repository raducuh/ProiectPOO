namespace DefaultNamespace;

public class Client:Utilizator
{
        public List<Event> EvenimenteDisponibile { get; private set; }
        public Client(int id, string nume, string prenume, string email, string parola) : base(id, nume, prenume, email,
                parola)
        {
                EvenimenteDisponibile = new List<Event>();
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
                        Console.WriteLine("Numar eveniment invalid.");
                        return;
                }
                
                // caut evenimentul selectat
                var eveniment = evenimente[evenimentIndex - 1];

                if (eveniment == null)
                {
                        Console.WriteLine("Evenimentul cu acest ID nu exista.");
                        return;
                }
                if (eveniment.Participanti.Contains(this)) // aici verific sa nu se inscrie de 2 ori la aceelasi eveniment
                {
                        Console.WriteLine($"Ati fost deja inscris la evenimentul '{eveniment.Nume}'!");
                        return;
                }
                // verific daca mai sunt locuri disponibile
                if (eveniment.Capacitate - eveniment.Participanti.Count <= 0)
                {
                        Console.WriteLine("Nu mai sunt locuri disponibile pentru acest eveniment.");
                        return;
                }
                // adaug clientul in lista
                eveniment.Participanti.Add(this);
                Console.WriteLine($"V-ati inscris cu succes la evenimentul '{eveniment.Nume}'!Va multumim!");

                // actualizez capacitatea 
                Console.WriteLine($"Locuri ramase: {eveniment.Capacitate - eveniment.Participanti.Count}");

        }
  
        public override void Meniu()
        {
                while (true)
                {
                        Console.WriteLine("Meniul  clientului:");
                        Console.WriteLine("1. Vizualizare evenimente.");
                        Console.WriteLine("2. Inscriere la eveniment.");
                        Console.WriteLine("3 Istoricul participarii dumneavoastra la evenimentele noastre.");
                        Console.WriteLine("4.Acordarea unui review.");
                        Console.WriteLine("5.Verificare update evenimente.");
                        int optiune = Convert.ToInt32(Console.ReadLine());

                        switch (optiune)
                        {
                                case 1:
                                        ObtineEvenimente();
                                        break;
                                case 2:
                                        InscriereLaEveniment(EvenimenteDisponibile);
                                        break;
                                case 3:
                                      
                                        break;
                                case 4:
                                        return;
                        }
                }
        }

        
        
}

        

 
        
        
        

        
