namespace ex03_Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> entiers = new List<int> { 4, 5, 2, 3, 1, 1, 0, 5, 8, 9, 10, 15, 16, 20, 21, 4, 5 };

            Console.WriteLine("Nombres supérieurs à 5");
            entiers.Where(x => x > 5).ToList().ForEach(Console.WriteLine);

            Console.WriteLine("Nombres supérieurs ou égaux à 15 et inférieurs à 20");
            entiers.Where(x => x >= 15 && x < 20).ToList().ForEach(Console.WriteLine);

            Console.WriteLine("Nombres supérieurs à 2, qui sont des multiples de 2, inférieurs à 20, différents de 8");
            entiers.Where(x => x > 2 && x % 2 == 0 && x < 20 && x != 8).ToList().ForEach(Console.WriteLine);

            List<string> fruits = new List<string> { "Banane", "Ananas", "Cerise", "Framboise", "Groseilles", "Pomme", "Poire", "Tomate", "Kiwi", "Raisin", "Mangue", "Datte" };
            Console.WriteLine("Tous les fruits dont le nom contient plus de 5 lettres");
            fruits.Where(x => x.Length > 5).ToList().ForEach(Console.WriteLine);

            Console.WriteLine("Tous les fruits dont le nom commence par \"P\", dont la longueur du nom est supérieure à 4, qui contiennent un \"o\" mais pas de \"m\"");
            fruits.Where(x => x.StartsWith("P") && x.Length > 4 && x.Contains("o") && !x.Contains("m")).ToList().ForEach(Console.WriteLine);

            Console.WriteLine("Trier et afficher les fruits selon leur longueur");
            fruits.OrderBy(x => x.Length).ToList().ForEach(Console.WriteLine);
        }
    }
}
