namespace DefaultNamespace;

public class Organizator:Utilizator
{
    public List<Event> Evenimente { get; set; }
    public List<Review> Reviews { get; set; }
    public Organizator(int id, string nume, string prenume, string email, string parola) : base(id, nume, prenume,
        email, parola)
    {
        Evenimente = new List<Event>();
        Reviews = new List<Review>();
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
            Console.WriteLine("Data introdusa nu este valida. Incercati din nou.");
        }

        Event nouEveniment = new Event( nume, descriere, capacitate, data);
        Evenimente.Add(nouEveniment);
        Console.WriteLine($"Evenimentul '{nume}' a fost lansat cu succes!");
    }

    public void AfisareEvenimente()
    {
        foreach (var eveniment in Evenimente)
        {
            Console.WriteLine($"{eveniment.Nume}, {eveniment.Descriere}, {eveniment.Capacitate}, {eveniment.Data.ToShortDateString()}");
        }
    }
    public void VerificareReviews()
    {
        foreach (var review in Reviews)
        {
          review.AcordareFeedback();
        }
    }
    
    //public void UpdateDetaliiEveniment()
    
}