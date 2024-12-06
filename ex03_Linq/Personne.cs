namespace ex03_Linq
{
    internal class Personne
    {
        public string LastName;
        public string FirstName;
        public bool IsEngineer;
        public int Age;
        public string Genre = string.Empty;

        public Personne(string lastName, string firstName)
        {
            LastName = lastName;
            FirstName = firstName;
        }

        public Personne(string lastName, string firstName, bool isEngineer) : this(lastName, firstName)
        {
            IsEngineer = isEngineer;
        }

        public Personne(string lastName, string firstName, int age, string genre) : this(lastName, firstName, false)
        {
            Age = age;
            Genre = genre;
        }
    }
}
