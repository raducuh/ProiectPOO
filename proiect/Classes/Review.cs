namespace DefaultNamespace;

public class Review
{
    public Client Persoana { get; set; }
    public int NumarStele { get; set; }

    public Review(Client persoana, int numarStele)
    {
        Persoana = persoana;
        NumarStele = numarStele;
        
    }

    public void AcordareFeedback()
    {
        int stele;
        Console.WriteLine("Evaluati evenimentul intre 1 si 5 stele: ");
        stele=int.Parse(Console.ReadLine());
        NumarStele = stele;
        if(NumarStele<=5 && NumarStele>=1)
            Console.WriteLine($"Ati acordat {NumarStele} stele. ");
        else
        {
            Console.WriteLine("Evaluare respinsa!Numarul introdus de stele trebuie sa fie intre 1 si 5!");
            
        }
    }
    
    
}