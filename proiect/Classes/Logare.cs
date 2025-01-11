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
        if( nume!=null && prenume!=null && email!=null && parola!=null)
         utilizator=new Utilizator(i,nume,prenume,email,parola);
        
        if (confirma == utilizator.Parola)
        {
            i++;
            Console.WriteLine("Autentificare reusita!");
            ListaUtilizatori.Add(utilizator);
        }
        
        if(confirma==parola)
            Console.WriteLine("Autentificare reusita!");

        else
        {
            Console.WriteLine("Ai gresit parola! Incearca sa te autentifici iar.");
        }

    }

    public void AfisareUtilizatori()
    {
        foreach (Utilizator utilizator1 in ListaUtilizatori)
        {
            Console.WriteLine($"{utilizator1.Nume},{utilizator1.Prenume}, {utilizator1.Email}");
        }

    }
}