
namespace DefaultNamespace;

public class Logare
{
    public List<Utilizator> ListaUtilizatori { get; private set; }
    private Utilizator utilizatorCurent;
    private List<string> emailuri;
    
    
    public Logare()
    {
        ListaUtilizatori = new List<Utilizator>();
        emailuri = new List<string>();
    }
    public void FunctieSpeciala()
    {
        Console.Write("Va rugam sa asteptati");
        for (int i = 0; i < 3; i++)
        {
            Console.Write(".");
            System.Threading.Thread.Sleep(500); // Pauză între puncte
        }
      
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
           FunctieSpeciala();
            Console.ForegroundColor = ConsoleColor.Green; 
            Console.WriteLine("\nAutentificare reusita!");
            Console.ResetColor();
            return true;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("EMAIL sau PAROLA INCORECTE!");
            Console.ResetColor();
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
            Console.ForegroundColor = ConsoleColor.Red; 
            Console.WriteLine("Optiune invalida! Alegeti 1 (Organizator) sau 2 (Client).");
            Console.ResetColor();
        }

        string nume = CitesteInputValid("Introduceti numele: ");
        string prenume = CitesteInputValid("Introduceti prenumele: ");
        string emailPrefix;
        while (true)
        {
            emailPrefix = CitesteInputValid("Introduceti emailul(doar partea dinainte de @gmail.com): ");
            if (emailuri.Contains(emailPrefix))
            {
                Console.ForegroundColor = ConsoleColor.Red; 
                Console.WriteLine($"Emailul: {emailPrefix}@gmail.com este deja utilizat! Introduceti alt email! (fara gmail.com) ");
                Console.ResetColor();
            }
            else
            {
                emailuri.Add(emailPrefix);
                break;
            }
        }

        string email = emailPrefix + "@gmail.com";
        string parola = CitesteInputValid("Introduceti parola: ");

        if (ListaUtilizatori.Any(u => u.Email == email))
        {
            Console.ForegroundColor = ConsoleColor.Red; // Mesaj de eroare
            Console.WriteLine($"Adresa de email {email} este deja utilizata! Va rugam sa folositi o alta adresa sau sa va autentificati.");
            Console.ResetColor();
            return; // aici verific daca email-ul e deja luat
        }
        if (tipUtilizator == 1)
        {
            Organizator organizatorNou = new Organizator(ListaUtilizatori.Count + 1, nume, prenume, email, parola);
            ListaUtilizatori.Add(organizatorNou);
            Console.ForegroundColor = ConsoleColor.Green; 
            Console.WriteLine("Organizator adaugat cu succes!");
            Console.ResetColor();
        }
        else if (tipUtilizator == 2)
        {
            Client clientNou = new Client(ListaUtilizatori.Count + 1, nume, prenume, email, parola);
            ListaUtilizatori.Add(clientNou);
            Console.ForegroundColor = ConsoleColor.Green; // Mesaj de succes
            Console.WriteLine("Client adaugat cu succes!");
            Console.ResetColor();
        }
    }
    public Utilizator GetUtilizatorCurent()
    {
        return utilizatorCurent;
    }
}