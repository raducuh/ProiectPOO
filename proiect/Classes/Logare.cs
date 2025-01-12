namespace DefaultNamespace;

public class Logare
{
    public List<Utilizator> ListaUtilizatori { get; private set; }
    private Utilizator utilizatorCurent;

    public Logare()
    {
        ListaUtilizatori = new List<Utilizator>();
    }

    public bool AutentificareUtilizator()
    {
        Console.WriteLine("Introduceti emailul: ");
        string email = Console.ReadLine();
        
        Console.WriteLine("Introduceti parola: ");
        string parola = Console.ReadLine();
        
        utilizatorCurent = ListaUtilizatori.FirstOrDefault(u => u.Email == email && u.Parola == parola);
        
        if (utilizatorCurent != null)
        {
            Console.WriteLine("Autentificare reusita!");
            return true;
        }
        else
        {
            Console.WriteLine("Email sau parola incorecte.");
            return false;
        }
    }

    public void Autentificare()
    {
        Console.WriteLine("Alege tipul de utilizator (1 - Organizator, 2 - Client): ");
        int tipUtilizator = Convert.ToInt32(Console.ReadLine());
        
        Console.WriteLine("Introduceti numele: ");
        string nume = Console.ReadLine();
        
        Console.WriteLine("Introduceti prenumele: ");
        string prenume = Console.ReadLine();
        
        Console.WriteLine("Introduceti emailul: ");
        string email = Console.ReadLine();
        
        Console.WriteLine("Introduceti parola: ");
        string parola = Console.ReadLine();
        
        if (tipUtilizator == 1)
        {
            Organizator organizatorNou = new Organizator(ListaUtilizatori.Count + 1, nume, prenume, email, parola);
            ListaUtilizatori.Add(organizatorNou);
            Console.WriteLine("Organizator adaugat cu succes!");
        }
        else if (tipUtilizator == 2)
        {
            Client clientNou = new Client(ListaUtilizatori.Count + 1, nume, prenume, email, parola);
            ListaUtilizatori.Add(clientNou);
            Console.WriteLine("Client adaugat cu succes!");
        }
    }

    public void AfisareUtilizatori()
    {
        foreach (Utilizator utilizator1 in ListaUtilizatori)
        {
            Console.WriteLine($"{utilizator1.Nume}, {utilizator1.Prenume}, {utilizator1.Email}");
        }
    }

    public Utilizator GetUtilizatorCurent()
    {
        return utilizatorCurent;
    }
}
