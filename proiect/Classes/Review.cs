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

    public void AcordareFeedback(Event eveniment)
    {
        //verific daca clientul a participat la eveniment
        if (!eveniment.Participanti.Contains(Persoana))
        {
            Console.WriteLine("Nu puteti acorda feedback acestui eveniment pentru ca nu ati participat!");
            return;
        }

        int stele;
        Console.WriteLine("Evaluati evenimentul intre 1 si 5 stele: ");
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out stele) && stele >= 1 && stele <= 5)
            {
                NumarStele = stele;
                Console.WriteLine($"Ati acordat {NumarStele} stele.");
                break; // ies din buclă dupa ce verific
            }
            else
            {
                Console.WriteLine("Numar invalid de stele! Introduceti un numar intre 1 si 5.");
            }
        }

    }
}
    
    
