namespace Animalerie.Models
{
    internal class Chien : Animal
    {
        public string CouleurCollier { get; set; }

        public bool Entraine { get; set; }

        public string Race { get; set; }

        public Chien() { ChanceDeMourir = 1.0; }


    }
}