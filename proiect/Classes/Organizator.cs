using System.Globalization;
using System.IO;
namespace DefaultNamespace;

public class Organizator:Utilizator
{
    public List<Event> Evenimente { get; set; }
    public List<Review> Reviews { get; set; }
    public List<Client> Clients { get; set; }
    private int eventID => Evenimente.Count + 1;
    public Organizator(int id, string nume, string prenume, string email, string parola) : base(id, nume, prenume,
        email, parola)
    {
        Evenimente = new List<Event>();
        Reviews = new List<Review>();
        Clients = new List<Client>();
    }
    
    public void LansareEveniment()
    {
        string nume, descriere;
        int capacitate;

        while (true)
        {
            Console.WriteLine("Introduceti un nume de eveniment: ");
            nume = Console.ReadLine();
            if (string.IsNullOrEmpty(nume))
            {
                Console.WriteLine("Numele evenimentului nu poate sa nu aiba niciun caracter sau sa fie null!");
                
            }
            else
            {
                break;
            }
            
        }

        while (true)
        {
            Console.WriteLine("Introduceti descrierea evenimentului: ");
            descriere = Console.ReadLine();
            if (string.IsNullOrEmpty(descriere))
            {
                Console.WriteLine("Descrierea evenimentului nu poate sa nu aiba niciun caracter sau sa fie null!");
            }
            else
            {
                break;
            }

        }

        while (true)
        {
            Console.WriteLine("Introduceti capacitatea: ");
            string  mesajCapacitate = Console.ReadLine();

            if (int.TryParse(mesajCapacitate, out capacitate) && capacitate > 0) 
            {
                break;
            }
            else
            {
                Console.WriteLine("Valoarea introdusa nu este valida sau este mai mica decat 1. Incercati din nou.");
            }
        }
        DateTime data;
        DateTime azi=DateTime.Now;
        string dataPtFisier;
        while (true)
        {
            Console.WriteLine("Introduceti data evenimentului (format: yyyy-MM-dd): ");
            string inputData = Console.ReadLine();

            if (DateTime.TryParse(inputData, out data) && data>=azi && data.Year<=2034)
            {
                Console.WriteLine($"Data introdusa este valida: {data}");
                
                break;
            }
            else
            {
                Console.WriteLine("Data introdusa nu este valida. Incercati din nou.");
            }
        }

        Event nouEveniment = new Event(eventID,nume, descriere, capacitate, data);
        Evenimente.Add(nouEveniment);
        Console.WriteLine($"Evenimentul '{nume}' a fost lansat cu succes!");
    }

    
    
    public void AfisareEvenimente()
    {
        foreach (var eveniment in Evenimente)
        {
            Console.WriteLine($"Nume eveniment:{eveniment.Nume}\n-------------\nTotal capacitate: {eveniment.Capacitate}\n-------------\nTotal participanti:{eveniment.Participanti.Count}");
        }
    }
    
    
    public void VerificareReviews()
    {
        foreach (var eveniment in Evenimente)
        {
            Console.WriteLine($"Eveniment: {eveniment.Nume}");
            if (eveniment.Reviews.Any())
            {
                foreach (var review in eveniment.Reviews)
                {
                    Console.WriteLine($"Review de la {review.Persoana.Nume}: {review.NumarStele} stele");
                }
            }
            else
            {
                Console.WriteLine("Nu exista review-uri pentru acest eveniment.");
            }
            Console.WriteLine("-------------------------");
        }
    }



    public void DetaliiEvenimentUpdate()
    {
        Console.WriteLine("Introduceti ID-ul evenimentului pentru care doriti sa trimiteti un update:");
        if (!int.TryParse(Console.ReadLine(), out int eventId))
        {
            Console.WriteLine("ID-ul trebuie sa fie un numar intreg.");
            return;
        }

        Event eveniment = Evenimente.FirstOrDefault(e => e.EventId == eventId);
        if (eveniment == null)
        {
            Console.WriteLine("Evenimentul cu acest ID nu exista.");
            return;
        }

        Console.WriteLine($"Eveniment selectat: {eveniment.Nume}");
        Console.WriteLine("Introduceti detalii/update-uri pentru participanti:");
        string mesaj = Console.ReadLine();

        foreach (var participant in eveniment.Participanti)
        {
            Console.WriteLine($"Mesaj trimis catre {participant.Nume}: {mesaj}");
        }

        Console.WriteLine($"Update-ul pentru evenimentul '{eveniment.Nume}' a fost trimis participantilor.");
    }

    public void SalvareEvenimenteInFisier()
    {
        foreach (var eveniment in Evenimente)
        {
            
        }
    }


    public void AddClient(Client client)
    {
        Clients.Add(client);
    }

    public override void AddUtilizator(Utilizator utilizator)
    {
        
    }
    
}