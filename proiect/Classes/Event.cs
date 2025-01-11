namespace DefaultNamespace;

public class Event
{
  
    public string Nume { get; set; }
    public string Descriere { get; set; }
    public int Capacitate { get; set; }
    public DateTime Data { get; set; }
    public List<Utilizator> Participanti { get; set; }
    public List<Review> Reviews { get; set; }

    public Event( string nume, string descriere, int capacitate, DateTime data)
    {
    
        Nume = nume;
        Descriere = descriere;
        Capacitate = capacitate;
        Data = data;
        Participanti = new List<Utilizator>();
        Reviews = new List<Review>();
    }
}