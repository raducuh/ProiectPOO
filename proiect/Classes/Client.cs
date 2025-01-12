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
        private void InscriereLaEveniment(List<Event> evenimente)
        {
        Console.Write("Introduceti numarul  evenimentului la care doresti sa participi: ");
                if (int.TryParse(Console.ReadLine(), out int idEveniment))
                {
                        
                        var evenimentAles = evenimente.FirstOrDefault(e => e.EventId == idEveniment);

                        if (evenimentAles != null) 
                        {
                                if (evenimentAles.Participanti.Count < evenimentAles.Capacitate) // Verific daca mai sunt locuri disponibile
                                {
                                        // Adaug clientul la evenimentul respectiv
                                        evenimentAles.Participanti.Add(this);
                                        EvenimenteDisponibile.Add(evenimentAles); // Adaugam evenimentul la istoricul clientului
                                        Console.WriteLine($"V-ati inscris cu succes la evenimentul \"{evenimentAles.Nume}\".");
                                }
                                else
                                {
                                        Console.WriteLine($"Evenimentul: \"{evenimentAles.Nume}\" a atins capacitatea maxima. Nu va puteti inscrie la eveniment..");
                                }
                        }
                        else
                        {
                                Console.WriteLine("ID-ul introdus nu corespunde niciunui eveniment.");
                        }
                }
                else
                {
                        Console.WriteLine("ID-ul introdus este invalid.");
                }

                //return evenimente;
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
                                        //InscriereLaEveniment(evenimente);
                                        break;
                                case 3:
                                      
                                        break;
                                case 4:
                                        return;
                        }
                }
        }

        
        
}

        

 
        
        
        
//o sa iti las aici comentariu, deci ar trebui sa faci cumva ca un Client sa poata sa isi aleaga la ce eveniment vrea sa mearga
//pt ca mai tarziu trb sa aflam cate persoane merg la un anumit eveniment, de ex. e evenimentul: nunta chiriac, trb sa aflam 
//cati clienti merg la nunta chiriac, la fel si pentru alt eveniment, etc.
// ok 

        
