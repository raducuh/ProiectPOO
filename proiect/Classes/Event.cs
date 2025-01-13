namespace DefaultNamespace;

public class Event
{
  
    public string Nume { get; set; }
    public string Descriere { get; set; }
    public int Capacitate { get; set; }
    public DateTime Data { get; set; }
    public int EventId { get; set; }
    public List<Utilizator> Participanti { get; set; }
    public List<Review> Reviews { get; set; }

    public Event(int eventId, string nume, string descriere, int capacitate, DateTime data)
    {
        EventId= eventId;
        Nume = nume;
        Descriere = descriere;
        Capacitate = capacitate;
        Data = data;
        Participanti = new List<Utilizator>();
        Reviews = new List<Review>();
    }

    public void AdaugaReview(Review review)
    {
        if (!Participanti.Contains(review.Persoana))
        {
            Console.WriteLine("Nu puteti adauga un review la un eveniment la care n-ati participat!");
            return;
        }
        Reviews.Add(review);
        Console.WriteLine("Review-ul dumneavoastra a fost adaugat!");
    }

    public void VizualizeazaReviewuri()
    {
        if (Reviews.Count == 0)
        {
Console.WriteLine("Nu exista niciun review pentru acest eveniment.");
return;
        }
        Console.WriteLine($"Review-uri pentru evenimentul '{Nume}':");
        foreach (var review in Reviews)
        {
            Console.WriteLine($"{review.Persoana.Nume} a acordat - {{review.NumarStele}} stele. ");
        }
    }

    public override string ToString()
    {
        return $"ID Eveniment: {EventId}\n" +
               $"Nume: {Nume}\n" +
               $"Descriere: {Descriere}\n" +
               $"Capacitate: {Capacitate}\n" +
               $"Data: {Data:yyyy-MM-dd}\n" +
               $"Participanti: {string.Join(", ", Participanti.Select(p => p.Nume))}\n";
    }
    
}

