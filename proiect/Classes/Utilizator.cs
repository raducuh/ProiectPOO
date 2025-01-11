namespace DefaultNamespace;

public class Utilizator
{
    public int Id { get ; private set; }
    public string Nume { get;private set; }
    public string Prenume { get;private set; }
    public string Email { get;private set; }
    public string Parola { get;private set; }
    
    public bool EsteLogat  { get;  set; }

    public Utilizator(int id, string nume, string prenume, string email, string parola)
    {
        Id = id;
        Nume = nume;
        Prenume = prenume;
        Email = email;
        Parola= parola;
    }
}