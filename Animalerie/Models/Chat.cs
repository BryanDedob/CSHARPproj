namespace Animalerie.Models
{
    internal class Chat : Animal
    {
        public string Caractere { get; set; }

        public bool GriffesCoupees { get; set; }

        public bool PoilLong { get; set; }

        public Chat() { ChanceDeMourir = 0.5; }





    }

}