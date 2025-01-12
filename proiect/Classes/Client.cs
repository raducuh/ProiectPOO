namespace DefaultNamespace;

public class Client:Utilizator
{
        public List<Event> IstoricEvenimente { get; private set; }
        public Client(int id, string nume, string prenume, string email, string parola) : base(id, nume, prenume, email,
                parola)
        {
                IstoricEvenimente = new List<Event>();
        }
        
        
        public override List<Event> ObtineEvenimente(List<Event> evenimente)
        {
                Console.WriteLine("Evenimente disponibile pentru client:");
                foreach (var eveniment in evenimente)
                {
                        Console.WriteLine($"ID:{eveniment.EventId}, Nume: {eveniment.Nume}, Data: {eveniment.Data}");
                }
                return evenimente;
        }

 
        
        
        
//o sa iti las aici comentariu, deci ar trebui sa faci cumva ca un Client sa poata sa isi aleaga la ce eveniment vrea sa mearga
//pt ca mai tarziu trb sa aflam cate persoane merg la un anumit eveniment, de ex. e evenimentul: nunta chiriac, trb sa aflam 
//cati clienti merg la nunta chiriac, la fel si pentru alt eveniment, etc.
// ok 

        
}