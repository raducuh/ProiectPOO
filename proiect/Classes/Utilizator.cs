namespace DefaultNamespace;

public class Utilizator
{
    public int Id { get ; private set; }
    public string Nume { get;private set; }
    public string Prenume { get;private set; }
    public string Email { get;private set; }
    public string Parola { get;private set; }
    public List<Utilizator> Useri { get;private set; }
    public List<Event> Evenimente { get; set; }
    
    public Utilizator(int id, string nume, string prenume, string email, string parola)
    {
        Id = id;
        Nume = nume;
        Prenume = prenume;
        Email = email;
        Parola= parola;
        Useri = new List<Utilizator>();
        Evenimente=new List<Event>();
    }

  

    public virtual void Meniu()
    {
        
    }
    
    public virtual void ObtineEvenimente()
    {
        
    }

 
}