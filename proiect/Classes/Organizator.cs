using System.Globalization;
using System.IO;
namespace DefaultNamespace;

public class Organizator:Utilizator
{
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
            if (string.IsNullOrEmpty(nume) || nume[0]==' ')
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
            if (string.IsNullOrEmpty(descriere) || descriere[0]==' ')
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
                Console.WriteLine($"Capacitatea introdusa este valida: {capacitate}");
               
                break;
            }
            else
            {
                Console.WriteLine("Valoarea introdusa nu este valida sau este mai mica decat 1. Incercati din nou.");
            }
        }
        DateTime data;
        DateTime azi=DateTime.Now;
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

    
    
    public override void ObtineEvenimente()
    {
        Console.WriteLine("Evenimente disponibile pentru organizator:");
        Console.WriteLine("--------------------");
        foreach (var eveniment in Evenimente)
        {
            Console.WriteLine($"ID: {eveniment.EventId}\n--------------------\nNume: {eveniment.Nume}\n-------------------- \nData: {eveniment.Data}\n--------------------\nLocuri totale: {eveniment.Capacitate}\n--------------------\nLocuri ramase: {eveniment.Capacitate - eveniment.Participanti.Count}");
        }
    }
    
    
    public void VerificareReviews()
    {
        foreach (var eveniment in Evenimente)
        {
            eveniment.VizualizeazaReviewuri();
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

        string directoryPath = Directory.GetCurrentDirectory();
        string folderName = "FisiereText";
        string folderPath = Path.Combine(directoryPath, folderName);

        
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        string fileName = $"Update_Eveniment_{eveniment.EventId}.txt";
        string filePath = Path.Combine(folderPath, fileName);

       
        using (StreamWriter writer = new StreamWriter(filePath, true)) 
        {
            writer.WriteLine($"Eveniment: {eveniment.Nume}");
            writer.WriteLine($"Data: {DateTime.Now}");
            writer.WriteLine($"Update trimis: {mesaj}");
          
            foreach (var participant in eveniment.Participanti)
            {
                writer.WriteLine($"- {participant.Nume}");
            }
            writer.WriteLine(new string('-', 40)); 
        }

        Console.WriteLine($"Update-ul pentru evenimentul '{eveniment.Nume}' a fost trimis participantilor si salvat in fisierul '{fileName}'.");
    }

    public void SalvareEvenimenteInFisier()
    {
        string directoryPath = Directory.GetCurrentDirectory();
        string folderName = "FisiereText";
        string folderPath = Path.Combine(directoryPath, folderName);

        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        string path = Path.Combine(folderPath, "evenimente.txt");

        using (StreamWriter writer = new StreamWriter(path, false)) 
        {
            foreach (var eveniment in Evenimente)
            {
                writer.WriteLine(eveniment.ToString());
                writer.WriteLine(new string('-', 40)); 
            }
        }

        Console.WriteLine("Evenimentele au fost salvate in fisierul 'evenimente.txt'.");
    }
}