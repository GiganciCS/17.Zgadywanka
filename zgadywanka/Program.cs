
namespace zgadywanka;

class Program
{
    static void Main(string[] args)
    {
        string[] rysunkiWisielca = UtworzRysunekWisielca();
        string[] tablicaHasel = UtworzListeHasel();
        string wylosowaneHaslo = WylosujHaslo(tablicaHasel);
        (string hasloDoWyswietlenia, int liczbaNieLiter) = ZakryjHaslo(wylosowaneHaslo);
        OdgadujHaslo(wylosowaneHaslo, hasloDoWyswietlenia, liczbaNieLiter, rysunkiWisielca);
    }

    private static void OdgadujHaslo(string wylosowaneHaslo, string hasloDoWyswietlenia, int liczbaNieLiter, string[] rysunkiWisielca)
    {
        int liczbaPomylek = 0;
        int liczbaOdslonietychLiter = 0;
        string uzyteLitery = "";

        while (liczbaOdslonietychLiter < wylosowaneHaslo.Length - liczbaNieLiter)
        {
            Console.Clear();
            Console.WriteLine(hasloDoWyswietlenia);
            Console.WriteLine(rysunkiWisielca[liczbaPomylek]);
            Console.WriteLine($"Użyte litery: {uzyteLitery}");
            Console.Write("Podaj literę: ");
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            char wpisanaLitera = Console.ReadLine()[0];
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            if (!uzyteLitery.Contains(wpisanaLitera))
            {
                uzyteLitery += wpisanaLitera;
                if (wylosowaneHaslo.Contains(wpisanaLitera) && !hasloDoWyswietlenia.Contains(wpisanaLitera))
                {
                    for(int i = 0; i < wylosowaneHaslo.Length; i++)
                    {
                        if(wylosowaneHaslo[i] == wpisanaLitera)
                        {
                            hasloDoWyswietlenia = hasloDoWyswietlenia.Remove(i, 1);
                            hasloDoWyswietlenia = hasloDoWyswietlenia.Insert(i, wpisanaLitera.ToString());
                            liczbaOdslonietychLiter++;
                        }
                    }
                }
                else
                {
                    liczbaPomylek++;
                    if(liczbaPomylek == rysunkiWisielca.Length-1)
                    {
                        Console.Clear();
                        Console.WriteLine(rysunkiWisielca[liczbaPomylek]);
                        Console.WriteLine($"Niestety, przegrana! Hasłem do odgadnięcia było: {wylosowaneHaslo}");
                        Thread.Sleep(3000);

                        return;
                    }
                }
            }
            else
            {
                Console.WriteLine("Ta litera została już użyta. Spróbuj ponownie");
            }

        }

        Console.WriteLine($"Brawo, wygrana! Hasłem było {wylosowaneHaslo}");
        Console.ReadKey();
    }

    private static (string hasloDoWyswietlenia, int liczbaNieLiter) ZakryjHaslo(string wylosowaneHaslo)
    {
        int liczbaNieLiter = 0;
        string hasloDoWyswietlenia = "";
        for (int i = 0; i < wylosowaneHaslo.Length; i++)
        {
            char znak = wylosowaneHaslo[i];
            if (char.IsLetter(znak))
            {
                hasloDoWyswietlenia += '_';
            }
            else
            {
                hasloDoWyswietlenia += znak;
                liczbaNieLiter++;
            }


        }
         return (hasloDoWyswietlenia, liczbaNieLiter);
    }

    private static string WylosujHaslo(string[] tablicaHasel)
    {
        Random maszynaLosujaca = new Random();
        int wylosowanyNumerHasla = maszynaLosujaca.Next(0, tablicaHasel.Length);
        return tablicaHasel[wylosowanyNumerHasla];
    }

    private static string[] UtworzListeHasel()
    {
        return new string[] {"programista", "obóz", "środowisko", "język programowania", "gigant"};
    }

    private static string[] UtworzRysunekWisielca()
    {
        return new string[]
        {
            "",
            @"
    +---+
    |   |
        |
        |
        |
        |
=========",
            @"
    +---+
    |   |
    O   |
        |
        |
        |
=========",
            @"
    +---+
    |   |
    O   |
    |   |
        |
        |
=========",
            @"
    +---+
    |   |
    O   |
   /|   |
        |
        |
=========",
            @"
    +---+
    |   |
    O   |
   /|\  |
        |
        |
=========",
            @"
    +---+
    |   |
    O   |
   /|\  |
   /    |
        |
=========",
            @"
    +---+
    |   |
    O   |
   /|\  |
   / \  |
        |
========="
        };
    }
}
