using System.Globalization;

namespace DefaultNamespace;

public class Organizator:Utilizator
{
    public List<Event> Evenimente { get; set; }
    public List<Review> Reviews { get; set; }
    public List<Client> Clients { get; set; }
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
        Console.WriteLine("Introduceti un nume de eveniment: ");
        nume= Console.ReadLine();
        Console.WriteLine("Introduceti descrierea evenimentului: ");
        descriere= Console.ReadLine();
        Console.WriteLine("Introduceti capacitatea: ");
        capacitate=int.Parse(Console.ReadLine());
        Console.WriteLine("Introduceti data evenimentului: ");
        DateTime data;
        Console.WriteLine("Introduceti data evenimentului (format: yyyy-MM-dd): ");
        string input = Console.ReadLine();

        if (DateTime.TryParse(input, out data))
        {
            Console.WriteLine($"Data introdusa este valida: {data}");
        }
        else
        {
            Console.WriteLine("Data introdusa nu este valida. Incercati din nou sa lansati un eveniment.");
            return;
        }

        Event nouEveniment = new Event( nume, descriere, capacitate, data);
        Evenimente.Add(nouEveniment);
        Console.WriteLine($"Evenimentul '{nume}' a fost lansat cu succes!");
    }

    public void AfisareEvenimente()
    {
        foreach (var eveniment in Evenimente)
        {
            Console.WriteLine($"Nume eveniment:{eveniment.Nume}\n-------------\nTotal capacitate: {eveniment.Capacitate}\n-------------\nTotal participanti:{Clients.Count}");
        }
    }
    public void VerificareReviews()
    {
        foreach (var review in Reviews)
        {
          review.AcordareFeedback();
        }
    }
    public void DetaliiEvenimentUpdate()
    {
        string mesaj;
        Console.WriteLine("Adaugati detalii/update-uri pentru participanti:");
        mesaj = Console.ReadLine();
        Console.WriteLine($"Ati transmis mai departe mesajul: {mesaj}");
    }

    public void AddClient(Client client)
    {
        Clients.Add(client);
    }
    
    //public void UpdateDetaliiEveniment()
    
}