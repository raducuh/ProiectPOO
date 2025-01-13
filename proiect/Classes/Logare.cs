
namespace DefaultNamespace;

public class Logare
{
    public List<Utilizator> ListaUtilizatori { get; private set; }
    private Utilizator utilizatorCurent;
   
    private const string FisierUtilizatori = "utilizatori.txt";

    public Logare()
    {
        ListaUtilizatori = new List<Utilizator>();
        IncarcaUtilizatoriDinFisier(); //retin toti utilizatorii
    }
 
    public bool AutentificareUtilizator()
    {
        Console.WriteLine("Introduceti emailul:(fara '@gmail.com', acesta se retine automat!" );
        string emailPrefix = Console.ReadLine();
        string email = emailPrefix+"@gmail.com";
        
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
            Console.WriteLine("EMAIL sau PAROLA INCORECTE!");
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
            Console.WriteLine("Inputul nu poate fi gol sau format doar din spatii. Va rugam sa incercati din nou.");
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
        string emailPrefix = CitesteInputValid("Introduceti emailul(doar partea dinainte de @gmail.com): ");
        string email = emailPrefix + "@gmail.com";
        string parola = CitesteInputValid("Introduceti parola: ");

        if (ListaUtilizatori.Any(u => u.Email == email))
        {
            Console.WriteLine($"Adresa de email {email} este deja utilizata! Va rugam a folositi o alta adresa sau sa va autentificati.");
            return; // aici verific daca email-ul e deja luat
        }
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
    private void SalveazaUtilizatoriInFisier()
    {
        using (StreamWriter writer = new StreamWriter(FisierUtilizatori))
        {
            foreach (var utilizator in ListaUtilizatori)
            {
                writer.WriteLine($"{utilizator.Id};{utilizator.Nume};{utilizator.Prenume};{utilizator.Email};{utilizator.Parola}");
            }
        }
    }
    private void IncarcaUtilizatoriDinFisier()
    {
        if (!File.Exists(FisierUtilizatori))
            return;

        foreach (var linie in File.ReadAllLines(FisierUtilizatori))
        {
            var date = linie.Split(';');
            if (date.Length == 5)
            {
                int id = int.Parse(date[0]);
                string nume = date[1];
                string prenume = date[2];
                string email = date[3];
                string parola = date[4];

                Utilizator utilizatorNou;
                if (email.Contains("organizator"))
                {
                    utilizatorNou = new Organizator(id, nume, prenume, email, parola);
                }
                else
                {
                    utilizatorNou = new Client(id, nume, prenume, email, parola);
                }

                ListaUtilizatori.Add(utilizatorNou);
            }
        }
    }

    public Utilizator GetUtilizatorCurent()
    {
        return utilizatorCurent;
    }
}