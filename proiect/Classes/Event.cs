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

