namespace ex03_Linq
{
    internal class Chien : Dog
    {
        public string Surname;
        public string Color;
        public string Gender;

        public Chien(string name, string surname, string breed, string color, string gender, int age, int poids) : base(breed, name, age, poids)
        {
            Surname = surname;
            Color = color;
            Gender = gender;
        }
    }
}
