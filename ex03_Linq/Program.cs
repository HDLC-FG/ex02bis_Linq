using System.Data;

namespace ex03_Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Exercice 1 : Requêtes simples
            Console.WriteLine("Exercice 1 : Requêtes simples\n");
            List<int> entiers = new List<int> { 4, 5, 2, 3, 1, 1, 0, 5, 8, 9, 10, 15, 16, 20, 21, 4, 5 };

            Console.WriteLine("1 - Nombres supérieurs à 5");
            entiers.Where(x => x > 5).ToList().ForEach(Console.WriteLine);

            Console.WriteLine("2 - Nombres supérieurs ou égaux à 15 et inférieurs à 20");
            entiers.Where(x => x >= 15 && x < 20).ToList().ForEach(Console.WriteLine);

            Console.WriteLine("3 - Nombres supérieurs à 2, qui sont des multiples de 2, inférieurs à 20, différents de 8");
            entiers.Where(x => x > 2 && x % 2 == 0 && x < 20 && x != 8).ToList().ForEach(Console.WriteLine);

            List<string> fruits = new List<string> { "Banane", "Ananas", "Cerise", "Framboise", "Groseilles", "Pomme", "Poire", "Tomate", "Kiwi", "Raisin", "Mangue", "Datte" };

            Console.WriteLine("4 - Tous les fruits dont le nom contient plus de 5 lettres");
            fruits.Where(x => x.Length > 5).ToList().ForEach(Console.WriteLine);

            Console.WriteLine("5 - Tous les fruits dont le nom commence par \"P\", dont la longueur du nom est supérieure à 4, qui contiennent un \"o\" mais pas de \"m\"");
            fruits.Where(x => x.StartsWith("P") && x.Length > 4 && x.Contains("o") && !x.Contains("m")).ToList().ForEach(Console.WriteLine);

            Console.WriteLine("6 - Trier et afficher les fruits selon leur longueur");
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

            Console.WriteLine("1 - Tous les noms des chiens qui sont de la race \"Berger Australien\"");
            dogs.Where(x => x.Breed.Equals("Berger Australien")).Select(x => x.Name).ToList().ForEach(Console.WriteLine);

            Console.WriteLine("2 - Tous les noms des chiens qui sont de la race \"Berger Australien\" et les trier par leur nom");
            dogs.Where(x => x.Breed.Equals("Berger Australien")).OrderBy(x => x.Name).Select(x => x.Name).ToList().ForEach(Console.WriteLine);

            Console.WriteLine("3 - Tous les noms des chiens âgés de 5 ans et plus, dont la longueur du nom est supérieure à 5 lettres...");
            dogs.Where(x => x.Age >= 5 && x.Name.Length > 5).Select(x => x.Name).ToList().ForEach(Console.WriteLine);

            Console.WriteLine("4 - Les trier par leur poids");
            dogs.OrderBy(x => x.Weight).Select(x => x.Name).ToList().ForEach(Console.WriteLine);

            Console.WriteLine("5 - Tous les noms des chiens par leur âge (tri décroissant) puis leur poids (tri croissant)");
            dogs.OrderByDescending(x => x.Age).ThenBy(x => x.Weight).Select(x => x.Name).ToList().ForEach(Console.WriteLine);

            Console.WriteLine("6 - Tous les noms des chiens dont le nom de race tient en un seul mot, leur poids doit être supérieur à 15 kilos, leur nom doit contenir un \"i\" et les trier par la longueur de leur prénom");
            dogs.Where(x => x.Breed.Split(" ").Count() == 1 && x.Weight > 15 && x.Name.Contains("i")).OrderBy(x => x.Name.Length).Select(x => x.Name).ToList().ForEach(Console.WriteLine);

            //Exercice 3 : Requêtes créant de nouveaux objets
            Console.WriteLine("\nExercice 3 : Requêtes créant de nouveaux objets\n");
            List<Personne> personnesExo3 = new List<Personne>
            {
                new Personne("Hallyday", "Johnny", false),
                new Personne("Vartan", "Sylvie", false),
                new Personne("Drucker", "Michel", false),
                new Personne("Antoine", "Antoine", true),
                new Personne("Philippe", "Edouard", false),
                new Personne("Demorand", "Patricia", true),
                new Personne("Ulysse", "Margareth", true),
                new Personne("Zenith", "Méryl", true),
                new Personne("Bobo", "Jojo", false)
            };

            Console.WriteLine("1 - Créer un itérable d'ingénieurs, trier par nom, et ensuite par prénom");
            personnesExo3.OrderBy(x => x.LastName).ThenBy(x => x.FirstName).Select(x => x.FirstName + " " + x.LastName).ToList().ForEach(Console.WriteLine);

            Console.WriteLine("2 - Récupérer et afficher la liste des personnes qui ne sont pas ingénieures");
            personnesExo3.Where(x => !x.IsEngineer).Select(x => x.FirstName + " " + x.LastName).ToList().ForEach(Console.WriteLine);

            Console.WriteLine("3 - Créer une liste d'objets anonymes (Ingénieurs + techniciens)");
            personnesExo3.Select(x => new { x.FirstName, x.LastName }).ToList().ForEach(Console.WriteLine);

            //Exercice 4 : Requêtes et variables
            Console.WriteLine("\nExercice 4 : Requêtes et variables\n");
            List<Personne> personnesExo4 = new List<Personne>
            {
                new Personne("Beauvoir", "Simon", 16, "M"),
                new Personne("Beauvoir", "Simone", 25, "F"),
                new Personne("De Caunes", "Richard", 41, "M"),
                new Personne("Sullivan", "Sullivan", 31, "M"),
                new Personne("Rémy", "Camille", 22, "F"),
                new Personne("Manchon", "Camille", 19, "M"),
                new Personne("Thiebaud", "Marie", 61, "F"),
                new Personne("Crouchon", "Mélanie", 55, "F"),
                new Personne("Baline", "Mélodie", 74, "F"),
                new Personne("Karine", "Pascal", 31, "M"),
                new Personne("Katherine", "Pascale", 36, "F"),
                new Personne("Zoula", "Charles", 20, "M"),
                new Personne("Romain", "Collin", 34, "M"),
                new Personne("Fouchard", "Aïcha", 48, "F"),
                new Personne("Blandine", "Maëva", 18, "F")
            };

            Console.WriteLine("1 - Créer une variable nom_complet = Nom + \" \" + Prenom et la mettre comme seule attribut de l'objet créé dans le select et les afficher");
            personnesExo4.Select(x =>
            {
                var Nom_complet = $"{x.LastName} {x.FirstName}";

                return new { Nom_complet };
            }).ToList().ForEach(Console.WriteLine);

            Console.WriteLine("2 - Pour les personnes majeures ayant moins de 50 ans...");
            personnesExo4.Where(x => x.Age >= 18 && x.Age < 50).Select(x =>
            {
                var initiale = x.LastName[0] + "." + x.FirstName[0];
                var taille_nom_complet = x.FirstName.Length + x.LastName.Length;

                return new
                {
                    Nom = x.LastName,
                    Prenom = x.FirstName,
                    initiale,
                    taille_nom_complet,
                    Age = x.Age
                };
            }).ToList().ForEach(Console.WriteLine);

            //Exercice 5 : Requêtes et listes à 2 dimensions
            Console.WriteLine("\nExercice 5 : Requêtes et listes à 2 dimensions\n");
            List<List<Personne>> personnesExo5 = new List<List<Personne>>
            {
                new List<Personne>
                {
                    new Personne("Drucker", "Michel"),
                    new Personne("Bedia", "Ramzy"),
                    new Personne("Judor", "Eric")
                },
                new List<Personne>
                {
                    new Personne("Diaz", "Cameron"),
                    new Personne("Depardieu", "Gerard"),
                    new Personne("Stallone", "Sylvester"),
                    new Personne("Macron", "Emmanuel")
                },
                new List<Personne>
                {
                    new Personne("Benzema", "Karim"),
                    new Personne("Antoine", "Eric"),
                    new Personne("Ruiz", "Olivia"),
                    new Personne("Clavier", "Christian"),
                    new Personne("Einstein", "Albert")
                }
            };

            Console.WriteLine("1 - Tous les noms dont la longueur est supérieure à 5");
            personnesExo5.ForEach(x => x
                .Where(x => x.LastName.Length > 5)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.FirstName} {x.LastName}")));

            Console.WriteLine("2 - Toutes personnes dont le nom contient un \"e\" et dont le prénom contient un \"a\"...");
            personnesExo5.ForEach(x => x
                .Where(x => x.LastName.Contains("e") && x.FirstName.Contains("a"))
                .OrderByDescending(x => x.LastName)
                .Select(x => new { identite = $"{x.FirstName} {x.LastName}" })
                .ToList()
                .ForEach(Console.WriteLine));

            Console.WriteLine("3 - Toutes les listes qui contiennent plus de 4 personnes...");
            personnesExo5.Where(x => x.Count > 4)
                .ToList()
                .ForEach(x => x
                    .Where(y => y.LastName.StartsWith("A")
                        || y.LastName.StartsWith("B")
                        || y.LastName.StartsWith("C")
                    )
                    .OrderBy(y => y.FirstName)
                    .Select(y => new { initiale = $"{y.FirstName[0]}.{y.LastName[0]}" }
                )
                .ToList()
                .ForEach(Console.WriteLine));

            Console.WriteLine("4 - Toutes les listes qui contiennent moins de 5 personnes et afficher toutes les personnes comme ceci : Nom+\" \"+Prenom");
            personnesExo5.Where(x => x.Count < 5)
                .ToList()
                .ForEach(x => x
                    .Select(y => new { initiale = $"{y.LastName} {y.FirstName}" }
                )
                .ToList()
                .ForEach(Console.WriteLine));

            //Exercice 6 : Requêtes et group by
            Console.WriteLine("\nExercice 6 : Requêtes et group by\n");
            List<Personne> personnesExo6 = new List<Personne>()
            {
                new Personne("Garett", "Ramzy", 45, "M"),
                new Personne("Caire", "Joe", 35, "M"),
                new Personne("Clay", "Alicia", 18, "F"),
                new Personne("Bavette", "Simone", 68, "F"),
                new Personne("Henry", "Thierry", 44, "M"),
                new Personne("Jacquesonne", "Janett", 25, "F"),
                new Personne("Buveur", "Joe", 25, "M"),
                new Personne("Louet", "Karim", 31, "M"),
                new Personne("Louette", "Karima", 31, "F"),
                new Personne("Caire", "Paul", 19, "M"),
                new Personne("Mille", "Camille", 20, "F"),
                new Personne("Cent", "Camille", 40, "F"),
                new Personne("Million", "Camille", 60, "M"),
                new Personne("Gold", "Roger", 17, "M"),
                new Personne("Lion", "Sandra", 8, "F"),
                new Personne("René", "Jean", 6, "M")
            };

            Console.WriteLine("1 - Faire un group by sur le genre des personnes présentes dans la liste d'objets Personne()");
            personnesExo6.GroupBy(x => x.Genre, x => x, (x, y) => new { Genre = x, Nombre = y.Count() })
                .ToList()
                .ForEach(Console.WriteLine);

            Console.WriteLine("2 - Faire un group by sur l'âge des personnes et les trier par âge croissant");
            personnesExo6.OrderBy(x => x.Age)
                .GroupBy(x => x.Age, x => x, (x, y) => new { Age = x, Nombre = y.Count() })
                .ToList()
                .ForEach(Console.WriteLine);

            Console.WriteLine("3 - Faire un group by sur le prénom des personnes, et afficher les noms de famille par prénom...");
            personnesExo6.Where(x => x.Age >= 18)
                .OrderByDescending(x => x.FirstName)
                .GroupBy(x => x.FirstName, x => x.LastName, (x, y) => new { NomsDeFamille = string.Join(", ", y) })
                .ToList()
                .ForEach(Console.WriteLine);

            List<int> nombresExo6 = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 20, 11, 13, 12, 14, 18, 17, 16, 14, 14 };

            Console.WriteLine("4 - Grouper les éléments d'une liste de nombres. D'un côté les chiffres/nombres pairs, de l'autre ceux impairs");
            nombresExo6.GroupBy(x => x % 2 == 0, x => x, (x, y) => new { Nombres = string.Join(", ", y) })
               .ToList()
               .ForEach(Console.WriteLine);

            Console.WriteLine("5 - Grouper les individus par la première lettre de leur nom et faire un tri croissant sur l'attribut Nom de la classe Personne");
            personnesExo6.OrderBy(x => x.LastName)
                .GroupBy(x => x.LastName[0], x => $"{x.FirstName} {x.LastName}", (x, y) => new { Noms = string.Join(", ", y) })
               .ToList()
               .ForEach(Console.WriteLine);

            //Exercice 7 : Requêtes et group by multiple
            Console.WriteLine("\nExercice 7 : Requêtes et group by multiple\n");
            List<DogV2> dogsExo7 = new List<DogV2>()
            {
                new DogV2("Gnocci", "Gnoc Gnoc", "Labrador", "Sable", "M", 1, 20),
                new DogV2("Vagabond", "Gros Loup", "Labrador", "Noir", "M", 8, 25),
                new DogV2("Milou", "Milos", "Labrador", "Sable", "M", 10, 24),
                new DogV2("Sirène", "Sissy", "Labrador", "Sable","F", 4, 19),
                new DogV2("Félicia", "Felicci", "Labrador", "Sable", "F", 6, 20),
                new DogV2("Kratos", "Mon tueur", "Chihuahua", "Fauve", "M", 1, 2),
                new DogV2("Jack", "Jaja", "Chihuahua", "Fauve", "M", 1, 2),
                new DogV2("Mojave", "Mojojo", "Chihuahua", "Fauve", "M", 1, 2),
                new DogV2("Hercule", "Herc", "Chihuahua", "Beige", "M", 35, 2),
                new DogV2("Médusa", "Med", "Terre-Neuve", "Noire", "F", 6, 40),
                new DogV2("Mélusine", "Mel", "Terre-Neuve", "Noire", "F", 7, 41),
                new DogV2("Venus", "Violette", "Terre-Neuve", "Noire", "F", 8, 38),
                new DogV2("Letto", "Lele", "Berger Australien", "Bleu Merle", "M", 3, 30),
                new DogV2("Cabron", "Dum dum", "Berger Australien", "Bleu Merle", "M", 9, 31),
                new DogV2("Banzaï", "Zaïzaï", "Berger Australien", "Noir et blanc", "M", 1, 28 ),
                new DogV2("Haricot", "Harry", "Berger Australien", "Noir et blanc", "M", 2, 27),
                new DogV2("Gédéon", "Gégé", "Berger Allemand", "Noir et feu", "M", 9, 31),
                new DogV2("Bella", "Belbel", "Berger Allemand", "Noir et feu", "F", 5, 28),
                new DogV2("Oui-oui", "oui", "Berger Allemand", "Sable", "M", 7, 35),
                new DogV2("Pataud", "Patoche", "Carlin", "Sable", "M", 16, 8),
                new DogV2("Killer", "Kiki", "Carlin", "Sable", "M", 10, 8),
                new DogV2("Frank", "Colonel", "Carlin", "Noir", "M", 9, 9)
            };

            Console.WriteLine("1 - Faire un group by multiple sur la race et la couleur et trier par ordre croissant la race, puis la couleur");
            dogsExo7.OrderBy(x => x.Breed)
                .ThenBy(x => x.Color)
                .GroupBy(x => new { x.Breed, x.Color }, x => x.Name, (x, y) => new { Filtre = x, Names = string.Join(", ", y) })
                .ToList()
                .ForEach(Console.WriteLine);

            Console.WriteLine("2 - Faire un group by multiple sur la couleur et le genre et trier par ordre croissant sur le genre");
            dogsExo7.OrderBy(x => x.Gender)
                .GroupBy(x => new { x.Color, x.Gender }, x => x.Name, (x, y) => new { Filtre = x, Names = string.Join(", ", y) })
                .ToList()
                .ForEach(Console.WriteLine);

            Console.WriteLine("3 - Faire un group by par genre, age, couleur...");
            dogsExo7.OrderBy(x => x.Gender)
                .GroupBy(x => new { x.Gender, x.Age, x.Color }, x => x.Name, (x, y) => new { Filtre = x, Names = string.Join(", ", y) })
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
