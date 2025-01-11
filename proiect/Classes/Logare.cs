namespace DefaultNamespace;

public class Logare
{
    public List<Utilizator> ListaUtilizatori { get; private set; }
    public void AddUtilizator()
    {
        Console.WriteLine("Introduceti un nume: ");
        string nume= Console.ReadLine();
        
        Console.WriteLine("Introduceti un email: ");
        string email= Console.ReadLine();
        
        Console.WriteLine("Introduceti o parola: ");
        string parola= Console.ReadLine();
        
        Console.WriteLine("Confirmare parola: ");
        string confirma= Console.ReadLine();
        
        if(confirma==parola)
            Console.WriteLine("Autentificare reusita!");
        else
        {
            Console.WriteLine("Ai gresit parola! Incearca sa te autentifici iar.");
        }
        
        
    }
}