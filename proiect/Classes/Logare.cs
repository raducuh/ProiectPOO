namespace DefaultNamespace;

public class Logare
{
    public List<Utilizator> ListaUtilizatori { get; private set; }
    private Utilizator utilizator;
    

    public Logare()
    {
        ListaUtilizatori = new List<Utilizator>();
    }
    
    public void AddUtilizator()
    {
        string confirma;
        int i=1;
        Console.WriteLine("Introduceti un nume: ");
        
        string nume= Console.ReadLine();
        
        Console.WriteLine("Introduceti un prenume: ");
        string prenume= Console.ReadLine();
        
        Console.WriteLine("Introduceti un email: ");
        string email= Console.ReadLine();
        
        Console.WriteLine("Introduceti o parola: ");
        string parola= Console.ReadLine();
       
        Console.WriteLine("Confirmare parola: ");
        confirma=Console.ReadLine();
        utilizator=new Utilizator(i,nume,prenume,email,parola);
        
        if (confirma == utilizator.Parola)
        {
            i++;
            Console.WriteLine("Autentificare reusita!");
            ListaUtilizatori.Add(utilizator);
        }
        else
        {
            Console.WriteLine("Ai gresit parola! Incearca sa te autentifici iar.");
        }
    }

    public void AfisareUtilizatori()
    {
        foreach (Utilizator utilizator in ListaUtilizatori)
        {
            Console.WriteLine($"{utilizator.Nume},{utilizator.Prenume}, {utilizator.Email}");
        }
    }
}