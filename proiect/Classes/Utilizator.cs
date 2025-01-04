namespace DefaultNamespace;

public class Utilizator
{
    public int ID { get; set; }
    public string Nume { get; set; }
    public string Prenume { get; set; }
    public string Email { get; set; }
    public string Parola { get; set; }

    public Utilizator(int id, string nume, string prenume, string email, string parola)
    {
        ID = id;
        Nume = nume;
        Prenume = prenume;
        

    }
}