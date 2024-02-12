
namespace Animalerie.Models
{
    internal class Animal
    {
        public string Nom { get; set; }
        public double Poids { get; set; }

        public double Taille { get; set; }

        public string Sexe { get; set; }

        public int Age { get; set; }

        public int AgeHumain { get; set; }

        public DateTime DateArrivee { get; set; }

        public double ChanceDeMourir { get; set; }

        public Animal() { ChanceDeMourir = 0.0; }
    }
}