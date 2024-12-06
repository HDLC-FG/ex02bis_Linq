namespace ex03_Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Exercice 1 : Requêtes simples
            Console.WriteLine("Exercice 1 : Requêtes simples\n");
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

            //Exercice 2 : Requêtes sur les objets
            Console.WriteLine("\nExercice 2 : Requêtes sur les objets\n");
            List<Dog> dogs = new List<Dog>
            {
                new Dog("Berger Australien", "Banzaï", 1, 28),
                new Dog("Berger Australien", "Letto", 3, 30),
                new Dog("Berger Australien", "Princesse", 8, 32),
                new Dog("Berger Allemand", "Floyd", 10, 32),
                new Dog("Caniche", "Igor", 13, 9),
                new Dog("Labrador", "Swing", 15, 25),
                new Dog("Teckel", "Wonki", 2, 5),
                new Dog("Terre Neuve", "Albator", 1, 50),
                new Dog("Carlin", "Pataud", 13, 10),
                new Dog("Boxer", "Frank", 6, 25),
                new Dog("Lévrier Afghan", "Précieuse", 9, 26),
                new Dog("Yorkshire", "Kakou", 3, 6)
            };

            Console.WriteLine("Tous les noms des chiens qui sont de la race \"Berger Australien\"");
            dogs.Where(x => x.Race.Equals("Berger Australien")).Select(x => x.Name).ToList().ForEach(Console.WriteLine);

            Console.WriteLine("Tous les noms des chiens qui sont de la race \"Berger Australien\" et les trier par leur nom");
            dogs.Where(x => x.Race.Equals("Berger Australien")).OrderBy(x => x.Name).Select(x => x.Name).ToList().ForEach(Console.WriteLine);

            Console.WriteLine("Tous les noms des chiens âgés de 5 ans et plus, dont la longueur du nom est supérieure à 5 lettres");
            dogs.Where(x => x.Age >= 5 && x.Name.Length > 5).Select(x => x.Name).ToList().ForEach(Console.WriteLine);

            Console.WriteLine("Les trier par leur poids");
            dogs.OrderBy(x => x.Poids).Select(x => x.Name).ToList().ForEach(Console.WriteLine);

            Console.WriteLine("Tous les noms des chiens par leur âge (tri décroissant) puis leur poids (tri croissant)");
            dogs.OrderByDescending(x => x.Age).ThenBy(x => x.Poids).Select(x => x.Name).ToList().ForEach(Console.WriteLine);

            Console.WriteLine("Tous les noms des chiens dont le nom de race tient en un seul mot, leur poids doit être supérieur à 15 kilos, leur nom doit contenir un \"i\" et les trier par la longueur de leur prénom");
            dogs.Where(x => x.Race.Split(" ").Count() == 1 && x.Poids > 15 && x.Name.Contains("i")).OrderBy(x => x.Name.Length).Select(x => x.Name).ToList().ForEach(Console.WriteLine);
        }
    }
}
