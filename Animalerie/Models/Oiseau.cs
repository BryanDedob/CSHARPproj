namespace Animalerie.Models
{
    internal class Oiseau : Animal
    {
        public string Couleur { get; set; }

        public string TypeDeCage { get; set; }

        public Oiseau() { ChanceDeMourir = 3.0; }

    }
}