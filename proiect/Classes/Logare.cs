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

    private string CitesteInputValid(string mesaj)
    {
        string input;
        while (true)
        {
            Console.WriteLine(mesaj);
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                break;
            }
            Console.WriteLine("Inputul nu poate fi gol sau format doar din spații. Vă rugăm să încercați din nou.");
        }
        return input;
    }
    public void Autentificare()
    {
        Console.WriteLine("Alege tipul de utilizator (1 - Organizator, 2 - Client): ");
        int tipUtilizator;
        while (!int.TryParse(Console.ReadLine(), out tipUtilizator) || (tipUtilizator != 1 && tipUtilizator != 2))
        {
            Console.WriteLine("Alegeti o optiune valida: 1 (Organizator) sau 2 (Client).");
        }

        string nume = CitesteInputValid("Introduceti numele: ");
        string prenume = CitesteInputValid("Introduceti prenumele: ");
        string email = CitesteInputValid("Introduceti emailul: ");
        string parola = CitesteInputValid("Introduceti parola: ");

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
 //obs: sa nu uitam sa tratam cazul in care pui spatiu la nume,prenume,etc